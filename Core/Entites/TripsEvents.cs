using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public  class TripsEvents : BaseEntity
    {
        public int RequestId { get; set; }
        public Requests Request { get; set; }
        public string UserId { get; set; }
        public Users User { get; set; }

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
