using Core.Entites.OrderEntities;
using Service.OrderService.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PaymentService.Interface
{
    public interface IPaymentService
    {
        Task<OrderResultDto?> CreateOrUpdatePaymentIntent(int id);
        Task<Order?> UpdateOrderStatus(string paymentIntentId, bool isPaid);
    }
}
