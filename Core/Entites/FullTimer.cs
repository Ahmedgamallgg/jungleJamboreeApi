using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class FullTimer : Crew
    {

        public DateTime HireDate { get; set;}

        [Column(TypeName = "Money")]
        public decimal Incentivies { get; set;}
    }
}
