using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin_Dashboard.Models
{
    public class CampViewModel
    {
        public int Id { get; set; }

        public string CampType { get; set; }

        public int Capacity { get; set; }

        [Range(4, 12)]
        public int AgeRange { get; set; }

        public decimal RegistrationFees { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public int LocationId { get; set; }
    }
}
