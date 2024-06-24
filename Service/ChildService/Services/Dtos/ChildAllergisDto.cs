using System.ComponentModel.DataAnnotations;

namespace Service.ChildService.Services.Dtos
{
    public class ChildAllergisDto
    {
        [Required]
        public int ChildId { get; set; }
        [Required]
        public string Allergies { get; set; }
        [Required]

        public string AllergiesDescreption { get; set; }
    }
}
