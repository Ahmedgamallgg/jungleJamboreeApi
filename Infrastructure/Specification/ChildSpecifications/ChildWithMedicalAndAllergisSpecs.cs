using Core.Entites;
using Infrastructure.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Specification.ChildSpecifications
{
    public class ChildWithMedicalAndAllergisSpecs : BaseSpecification<Child>
    {
        public ChildWithMedicalAndAllergisSpecs(string? userId)
          : base(s =>
              (string.IsNullOrEmpty(userId) || s.UserId == userId)
                )
        {
            AddInclude(p => p.ChildAllergis);
            AddInclude(p => p.ChildMedicalConditions);
            AddInclude(p => p.ChildCamp);


        }
        public ChildWithMedicalAndAllergisSpecs(int? id, string? userId)
            : base(s => (s.Id == id) && (string.IsNullOrEmpty(userId) || s.UserId == userId))
        {
            AddInclude(p => p.ChildAllergis);
            AddInclude(p => p.ChildMedicalConditions);
            AddInclude(p => p.ChildCamp);



        }
        public ChildWithMedicalAndAllergisSpecs(int? id)
          : base(s =>
              (!id.HasValue || s.Id == id)
                )
        {
            AddInclude(p => p.ChildAllergis);
            AddInclude(p => p.ChildMedicalConditions);
            AddInclude(p => p.ChildCamp);
            AddInclude(p => p.User);


        }
        public ChildWithMedicalAndAllergisSpecs()
          : base(s =>
              (true)
                )
        {
            AddInclude(p => p.ChildAllergis);
            AddInclude(p => p.ChildMedicalConditions);
            AddInclude(p => p.ChildCamp);
            AddInclude(p => p.User);


        }
    }
}
