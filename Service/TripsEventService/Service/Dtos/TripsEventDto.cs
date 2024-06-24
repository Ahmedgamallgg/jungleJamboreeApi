using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.TripsEventService.Service.Dtos
{
    public class TripsEventDto
    {



        public string Destnation { get; set; }
        public string Activity { get; set; }

        public string Type { get; set; }
        [MaxLength(50)]
        public string AdditionalInfo { get; set; }

        public DateTime Date { get; set; }
        [Column(TypeName = "money")]
        public decimal BudgetPerPerson { get; set; }

        public int NumberPerPerson { get; set; }

    }
}
