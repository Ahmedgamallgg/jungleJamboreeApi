using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites.OrderEntities;

namespace Service.OrderService.Service.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        [EmailAddress]
        public string BuyerEmail { get; set; }
        public int PurchasedCampId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal TotalMoney { get; set; }

        public int ChildId { get; set; }
    }
}
