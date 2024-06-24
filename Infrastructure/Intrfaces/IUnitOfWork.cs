
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites;
using Infrastracture.Intrfaces;

namespace Infrastracture.Interfaces
{
    public interface IUnitOfWork 
    {
        IGenericRepository<TEntity> Reposatory<TEntity>() where TEntity : BaseEntity;

        Task<int> Complete();
    }
}
