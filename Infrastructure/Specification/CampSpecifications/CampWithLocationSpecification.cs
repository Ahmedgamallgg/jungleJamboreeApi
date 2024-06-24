using Core.Entites;
using Infrastructure.Specification;

namespace Infrastracture.Specification.CampSpecifications
{
    public class CampWithLocationSpecification : BaseSpecification<Camp>
    {
        public CampWithLocationSpecification() : base(c => c.Id == c.Id)
        {
            Includes.Add(c => c.Location);
            Includes.Add(c => c.ChildCamp);
        }
        public CampWithLocationSpecification(int id)
            : base(camp =>
                    (camp.Id == id) 
                  )
        {
            AddInclude(Camp => Camp.Location);
            Includes.Add(c => c.ChildCamp);


        }
    }
    public class CampWithLocationSpecs: BaseSpecification<Camp>
    {
        public CampWithLocationSpecs() : base(c => c.Id == c.Id)
        {
            Includes.Add(c => c.Location);

        }
        public CampWithLocationSpecs(int id)
            : base(camp =>
                    (camp.Id == id)
                  )
        {
            AddInclude(Camp => Camp.Location);



        }
    }
}
