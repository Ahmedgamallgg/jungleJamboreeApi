using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Admin_Dashboard.Models
{
    public class childViewModel
    {
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        public string FName { get; set; }

        [MaxLength(10)]
        [Required]

        public string Lname { get; set; }
        [Phone]
        [MaxLength(13)]
        [Required]

        public string EmergencyContact { get; set; }
        [Required]

        public Gender Gender { get; set; }
        [Required]
        public DateOfBirth DOB { get; set; }

        public List<string> MedicalConditions { get; set; }

        public List<string> Allergies { get; set; }

        public string ParentName { get; set; }
    }
}
