namespace Core.Entites
{
    public class ChildAllergis : BaseEntity
    {
        public int ChildId { get; set; }
        public Child Child { get; set; }

        public string Allergies { get; set; }

        public string AllergiesDescreption { get; set; }


    }
}
