using Microsoft.EntityFrameworkCore;

namespace Core.Entites
{
    public enum PaymentMethod
    {
        Cash,
        Visa
    }
    public class ChildCamp : BaseEntity
    {
        
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int CampId { get; set; }
        public Camp Camp { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

    }
}
