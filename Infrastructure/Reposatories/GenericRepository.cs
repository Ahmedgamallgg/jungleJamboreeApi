using Core;
using Core.Context;
using Core.Entites;
using Infrastracture.Intrfaces;
using Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
 
namespace Infrastracture.Reposatories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly JungleJumboreeDbContext _context;

        public GenericRepository(JungleJumboreeDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity)
        => _context.Set<T>().Remove(entity);
         
        public async Task<IReadOnlyList<T>> GetAllAsync()
        =>await _context.Set<T>().ToListAsync();

        public async Task<T> GetByAsynsc(long id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> GetAllWithSpecificationsAsync(ISpecification<T> specification)
            => await ApplySpecification(specification).ToListAsync();


        public async Task<T> GetByIdWithSpecificationsAsync(ISpecification<T> specification)
            => await ApplySpecification(specification).FirstOrDefaultAsync();


        public void Update(T entity)
        => _context.Set<T>().Update(entity);

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
            => SpecificationEvaluater<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);

        public async Task<T> GetByAsynsc(int id)
        => await _context.Set<T>().FindAsync(id);
    }
}
