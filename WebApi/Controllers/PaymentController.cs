using Core.Entites.OrderEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.OrderService.Service.Dtos;
using Service.PaymentService.Interface;
using Stripe;
using WebApi.HandelResponses;

namespace WebApi.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        // This is your Stripe CLI webhook secret for testing your endpoint locally.
        private const string whSecret = "whsec_78bcfc35a894f4b5a37263c101866d388d457f57d66d0de7aab9315e145e5f30";

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [Authorize]

        [HttpGet]
        public async Task<ActionResult<OrderResultDto>> CreateOrUpdatePaymentIntent(int id)
        {
            var order = await _paymentService.CreateOrUpdatePaymentIntent(id);
            if (order is null) return BadRequest(new ApiResponse(400, "An Error With Your Backet Has Occured"));

            return Ok(order);
        }


        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeEvent = EventUtility.ConstructEvent(json,
                Request.Headers["Stripe-Signature"], whSecret);

            var paymentIntent = (PaymentIntent)stripeEvent.Data.Object;

            Order? order;

            switch (stripeEvent.Type)
            {
                case Events.PaymentIntentSucceeded:
                    order = await _paymentService.UpdateOrderStatus(paymentIntent.Id, true);
                    _logger.LogInformation("Order Is Succeeded: {0}", order?.PaymentIntentId);
                    _logger.LogInformation("Unhandeld Event Type: {0}", stripeEvent.Type);
                    break;
                case Events.PaymentIntentPaymentFailed:
                    order = await _paymentService.UpdateOrderStatus(paymentIntent.Id, false);
                    _logger.LogInformation("Order Is Failed: {0}", order?.PaymentIntentId);
                    _logger.LogInformation("Unhandeld Event Type: {0}", stripeEvent.Type);
                    break;
            }

            return Ok();
        }
    }
}
