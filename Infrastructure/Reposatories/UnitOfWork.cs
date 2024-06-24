using Core.Context;
using Core.Entites;
using Infrastracture.Interfaces;
using System.Collections;
using Infrastracture.Intrfaces;
using Infrastracture.Reposatories;

namespace Infrastructure.Reposatories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JungleJumboreeDbContext _Context;
        private Hashtable _repositories;

        public UnitOfWork(JungleJumboreeDbContext context)
        {
            _Context = context;
        }
        public async Task<int> Complete()
            => await _Context.SaveChangesAsync();



        public IGenericRepository<TEntity> Reposatory<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repsitoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _Context);
                _repositories[type] = repsitoryInstance;
            }

            return (IGenericRepository<TEntity>)_repositories[type];


            
            
        }
    }
}
