
namespace HospitalRegistrySystem.DAL.Repositories.Inerfaces {
    public interface IGenericRepository<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity> {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
