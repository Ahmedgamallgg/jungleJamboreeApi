using Core.Entites;

namespace Service.ChildService.Services.Dtos
{
    public class ChildCampDto
    {
        public int ChildId { get; set; }
        public int CampId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
