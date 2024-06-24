using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Core.Entites
{
    public class Company : BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string FName { get; set; }

        [MaxLength(10)]
        public string Lname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<TripsEvents> TripsEvents { get; set; }
    }
}
