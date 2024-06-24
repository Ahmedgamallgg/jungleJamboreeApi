using Core.Entites;
using Infrastructure.Specification;

namespace Infrastracture.Intrfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {   
        Task<T> GetByAsynsc(int id);
        Task<T> GetByAsynsc(long id);

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdWithSpecificationsAsync(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetAllWithSpecificationsAsync(ISpecification<T> specification);

        Task Add(T entity); 
        void Update(T entity);
        void Delete(T entity);





    }
}
