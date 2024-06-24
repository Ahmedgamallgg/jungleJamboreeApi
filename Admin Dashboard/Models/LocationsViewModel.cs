using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_Dashboard.Models
{
    public class LocationViewModel
    {
        public int Id { get; set; }

        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "money")]
        public decimal RentalFees { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public string Type { get; set; }
        public int[]? Crews { get; set; }

        public string? CampName { get; set; }
    }

}
