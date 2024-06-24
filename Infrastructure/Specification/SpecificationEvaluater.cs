using Core.Entites;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Specification
{
    public class SpecificationEvaluater<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T>specification)
        {
            var query = inputQuery;

            if(specification.Criteria != null)
                query = query.Where(specification.Criteria);


            if(specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);
            

            if (specification.OrderByDesc != null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if(specification.isPaginated)
                query = query.Skip(specification.Skip).Take(specification.Take);
            

            query = specification.Includes.Aggregate(query,(current, include) => current.Include(include));

            return query;
        }
    }
}
