using Core.Entites.OrderEntities;
using Core.Migrations;

namespace Infrastructure.Specification
{
    public class OrderWithPaymentIntentSpecification : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentSpecification(string? paymentIntentId, int? childId) 
            : base(order => 
            (string.IsNullOrEmpty(paymentIntentId)||order.PaymentIntentId == paymentIntentId) &&
            (!childId.HasValue || order.ChildId == childId)

            )
        {
        }
        
    }
    public class OrderWithSpecification : BaseSpecification<Order>
    {
        public OrderWithSpecification(string? BuyerEmail)
            : base(order =>
            (string.IsNullOrEmpty(BuyerEmail) || order.BuyerEmail == BuyerEmail) 

            )
        {
        }
        public OrderWithSpecification(int id, string? BuyerEmail)
            : base(order =>
            order.Id == id &&
            (string.IsNullOrEmpty(BuyerEmail) || order.BuyerEmail == BuyerEmail) 

            )
        {
        }

    }
}
