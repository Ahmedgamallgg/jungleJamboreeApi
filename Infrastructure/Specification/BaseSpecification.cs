using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool isPaginated { get; private set; }

        protected void ApplyPagination(int skip , int take)
        {
            Take = take;
            Skip = skip;
            isPaginated = true;
        }

        protected void AddInclude(Expression<Func<T, object>> include)
            => Includes.Add(include);

        protected void AddOrderBy(Expression<Func<T, object>> orderBy)
            => OrderBy = orderBy;
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDesc)
            => OrderByDesc = orderByDesc;


    }
}
