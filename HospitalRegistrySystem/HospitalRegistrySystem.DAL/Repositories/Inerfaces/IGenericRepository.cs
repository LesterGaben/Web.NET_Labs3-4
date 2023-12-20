using System.Linq.Expressions;

namespace HospitalRegistrySystem.DAL.Repositories.Inerfaces {
    public interface IGenericRepository<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity> {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(object id);
        public Task<IEnumerable<TEntity>> GetAllIncludingAsync(Expression<Func<TEntity, object>> includeProperty);
        public Task<TEntity> GetByIdIncludingAsync(int id, Expression<Func<TEntity, object>> includeProperty);
        public Task AddAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);
    }
}
