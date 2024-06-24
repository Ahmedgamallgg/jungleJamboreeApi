using Core.Entites;
using Infrastructure.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Specification.ChildSpecifications
{
    public class CHildWIthCampSpecs : BaseSpecification<Child>
    {
        public CHildWIthCampSpecs(string? userId)
          : base(s =>
              (string.IsNullOrEmpty(userId) || s.UserId == userId)
                )
        {
            Includes.Add(c => c.ChildCamp);

        }
        public CHildWIthCampSpecs(int? id)
            : base(s => s.Id == id)
        {

            Includes.Add(c => c.ChildCamp);



        }
        public CHildWIthCampSpecs(int? id, string userId)
            : base(s => (s.Id == id) && (string.IsNullOrEmpty(userId) || s.UserId == userId))

        {
            Includes.Add(c => c.ChildCamp);





        }
    }
}
