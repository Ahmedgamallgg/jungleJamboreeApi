using Core.Entites.OrderEntities;
using Microsoft.AspNetCore.Mvc;
using Service.OrderService.Interface;
using Service.OrderService.Service.Dtos;
using Stripe.Climate;
using System.Security.Claims;
using WebApi.HandelResponses;

namespace WebApi.Controllers
{

    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrderAsync(OrderDto orderDto)
        {
            var order = await _orderService.CreateOrderAsync(orderDto);
            if(order == null)
                return BadRequest(new ApiResponse(400, "PLease Try Again Later"));

            return Ok(order);

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetAllOrdersAsync()
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            var orders = await _orderService.GetOrderForUser(email);
            if (orders == null)
                return BadRequest(new ApiResponse(400, "PLease Try Again Later"));
            return Ok(orders);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrderByIdAsync(int id)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            var order = await _orderService.GetOrderByIdForUserAsync(id,email);
            if (order == null)
                return BadRequest(new ApiResponse(400, "PLease Try Again Later"));
            return Ok(order);
        }
    }
}
