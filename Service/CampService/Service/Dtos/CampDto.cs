using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CampService.Service.Dtos
{
    public class CampDto
    {
        public int Id { get; set; }

        public string CampType { get; set; }

        public int Capacity { get; set; }

        [Range(4, 12)]
        public int AgeRange { get; set; }

        [Column(TypeName = "Money")]
        public decimal RegistrationFees { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public string LocationName { get; set; }

    }
}
