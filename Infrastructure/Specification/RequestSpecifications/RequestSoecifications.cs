using Core.Entites;
using Infrastructure.Specification;

namespace Infrastracture.Specification.RequestSpecifications
{
    public class RequestSpecifications : BaseSpecification<Requests>
    {
        public RequestSpecifications(int id) : base(s => s.Id == id)
        {
            AddInclude(s => s.TripsEvents);
            AddInclude(s => s.NewStaff);

        }
    }
}
