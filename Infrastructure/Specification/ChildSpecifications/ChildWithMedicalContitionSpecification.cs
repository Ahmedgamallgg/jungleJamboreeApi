using Core.Entites;
using Infrastructure.Specification;
namespace Infrastracture.Specification.ChildSpecifications
{
    public class ChildWithMedicalContitionSpecification: BaseSpecification<Child>
    {
        public ChildWithMedicalContitionSpecification(string? userId)
          : base(s =>
              (string.IsNullOrEmpty(userId) || s.UserId == userId)
                )
        {
            AddInclude(p => p.ChildMedicalConditions);

        }
        public ChildWithMedicalContitionSpecification(int? id)
            : base(s => s.Id == id)
        {
            AddInclude(p => p.ChildMedicalConditions);



        }
        public ChildWithMedicalContitionSpecification(int? id, string userId)
            : base(s => (s.Id == id) && (string.IsNullOrEmpty(userId) || s.UserId == userId))

        {
            AddInclude(p => p.ChildMedicalConditions);



        }
    }
}
