using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin_Dashboard.Models
{
    public class CrewViewModel
    {

        public long SSN { get; set; }


        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }
        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Position { get; set; }

        public int WorkHours { get; set; }

        public string Type { get; set; }




    }
}
