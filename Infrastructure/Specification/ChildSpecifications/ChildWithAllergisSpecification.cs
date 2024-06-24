using Core.Entites;
using Infrastructure.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Specification.ChildSpecifications
{
    public class ChildWithAllergisSpecification : BaseSpecification<Child>
    {
        public ChildWithAllergisSpecification(string? userId)
           : base(s =>
               (string.IsNullOrEmpty(userId) || s.UserId == userId)
                 )
        {
            AddInclude(p => p.ChildAllergis);

        }
        public ChildWithAllergisSpecification(int? id)
            : base(s => s.Id == id)
        {
            AddInclude(p => p.ChildAllergis);
            AddInclude(p => p.ChildCamp);
            


        }
        public ChildWithAllergisSpecification(int? id, string userId    )
            : base(s => (s.Id == id) && (string.IsNullOrEmpty(userId) || s.UserId == userId))

        {
            AddInclude(p => p.ChildAllergis);



        }

    }
}
