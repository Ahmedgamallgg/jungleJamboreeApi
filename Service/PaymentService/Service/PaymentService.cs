using AutoMapper;
using Core.Entites;
using Core.Entites.OrderEntities;
using Infrastracture.Interfaces;
using Infrastructure.Specification;
using Microsoft.Extensions.Configuration;
using Service.OrderService.Service.Dtos;
using Service.PaymentService.Interface;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PaymentService.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(
            IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<OrderResultDto?> CreateOrUpdatePaymentIntent(int orderId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var order = await _unitOfWork.Reposatory<Order>().GetByAsynsc(orderId);
            if (order is null) return null;

            var camp = await _unitOfWork.Reposatory<Camp>().GetByAsynsc(order.PurchasedCampId);

            order.TotalMoney = camp.RegistrationFees;
            var orderdto = new OrderResultDto();

            PaymentIntent paymentIntent;
            PaymentIntentService paymentIntentService = new PaymentIntentService();

            if (string.IsNullOrEmpty(order.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions()
                {
                    Amount = (long)order.TotalMoney * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>() { "card" }
                };

                paymentIntent = await paymentIntentService.CreateAsync(options);

                order.PaymentIntentId = paymentIntent.Id;
                orderdto = _mapper.Map<OrderResultDto>(order);

                orderdto.ClientSecret = paymentIntent.ClientSecret;

            }
            else
            {
                var options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)order.TotalMoney * 100
                };

                await paymentIntentService.UpdateAsync(order.PaymentIntentId, options);
            }

             _unitOfWork.Reposatory<Order>().Update(order);

            return orderdto;
        }

        public async Task<Order?> UpdateOrderStatus(string paymentIntentid, bool isPaid)
        {
            var orderRepo = _unitOfWork.Reposatory<Order>();

            var spec = new OrderWithPaymentIntentSpecification(paymentIntentId: paymentIntentid, null);

            var order = await orderRepo.GetByIdWithSpecificationsAsync(spec);

            if (order is null) return null;

            if (isPaid)
                order.Status = OrderStatus.PaymentReceived;
            else
                order.Status = OrderStatus.PaymentFailed;

            orderRepo.Update(order);

            await _unitOfWork.Complete();

            return order;

        }
    }
}

