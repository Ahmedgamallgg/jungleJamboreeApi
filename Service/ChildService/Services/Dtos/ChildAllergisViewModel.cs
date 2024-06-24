using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ChildService.Services.Dtos
{
    public class ChildAllergisViewModel
    {

        [MaxLength(10)]
        [Required]
        public string FName { get; set; }

        [MaxLength(10)]
        [Required]

        public string Lname { get; set; }

        public ICollection<ChildAllergisDto> Allergis { get; set; }

    }
}
