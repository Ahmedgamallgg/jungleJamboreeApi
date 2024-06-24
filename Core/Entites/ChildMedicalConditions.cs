namespace Core.Entites
{
    public class ChildMedicalConditions : BaseEntity
    {
        public int ChildId { get; set; }
        public Child Child { get; set; }


        public string MedicalConditions { get; set; }

        public string MedicalConditionsDescreption { get; set; }

    }
}
