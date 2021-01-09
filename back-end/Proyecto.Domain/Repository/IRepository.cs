using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(int id);

        Task<TEntity> Save(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}