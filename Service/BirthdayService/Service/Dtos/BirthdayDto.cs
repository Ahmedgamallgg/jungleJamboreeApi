using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Service.BirthdayService.Service.Dtos
{
    public class BirthdayDto
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [Range(5, 100)]
        public int GuestCount { get; set; }
        public string Activity { get; set; }
        public string Theme { get; set; }
        public int ChildId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int LocationId { get; set; }
    }
}
