using Core.Entites.OrderEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.OrderService.Service.Dtos
{
    public class OrderResultDto
    {
        public int Id { get; set; }
        [EmailAddress]
        public string BuyerEmail { get; set; }
        public int PurchasedCampId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalMoney { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;


        public int ChildId { get; set; }


        public string?  PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }

    }
}
