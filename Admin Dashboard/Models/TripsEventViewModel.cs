using Core.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin_Dashboard.Models
{
    public class TripsEventViewModel
    {
        public int RequestId { get; set; }
        public string UserId { get; set; }

        public string Destnation { get; set; }
        public string Activity { get; set; }

        public string Type { get; set; }
        [MaxLength(50)]
        public string AdditionalInfo { get; set; }

        public DateTime Date { get; set; }
        [Column(TypeName = "money")]
        public decimal BudgetPerPerson { get; set; }

        public int NumberPerPerson { get; set; }


        public RequestType State { get; set; } = RequestType.Pending;
    }
}
