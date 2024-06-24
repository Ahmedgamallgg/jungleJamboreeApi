using Core.Entites;
using Infrastructure.Specification;

namespace Infrastracture.Specification.LocationSpecifications
{
    public class LocationWIthCampSpecs : BaseSpecification<Location>
    {
        public LocationWIthCampSpecs(int id) : base(s => s.Id == id)
        {
            AddInclude(p => p.Camp);
            AddInclude(p => p.CrewLocations);

        }
        public LocationWIthCampSpecs() : base(s => true)
        {
            AddInclude(p => p.Camp);
            AddInclude(p => p.CrewLocations);

        }
    }
}
