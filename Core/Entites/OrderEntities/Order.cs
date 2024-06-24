using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites.OrderEntities
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Payment Received")]
        PaymentReceived,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }

    public class Order :BaseEntity
    {
        public int Id { get; set; }
        [EmailAddress]
        public string BuyerEmail { get; set; }
        public int PurchasedCampId { get; set; }
        public Camp PurchasedCamp { get; set; }
        [Column(TypeName ="money")]
        public decimal TotalMoney { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public int ChildId { get; set; }

        public Child Child { get; set; }
        public string? PaymentIntentId { get; set; } = string.Empty;
    }
}
