using HospitalRegistrySystem.DAL.Context;
using HospitalRegistrySystem.DAL.Entities.Abstract;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace HospitalRegistrySystem.DAL.Repositories {
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity  {

        private readonly HospitalRegistrySystemContext _context;
        private readonly DbSet<TEntity> _entities;
        public Type EntityType => ((IQueryable<TEntity>)_entities).ElementType;

        public Type ElementType { get; }
        public Expression Expression => ((IQueryable<TEntity>)_entities).Expression;

        public IQueryProvider Provider => ((IQueryable<TEntity>)_entities).Provider;


        public GenericRepository(HospitalRegistrySystemContext context) {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public IEnumerator<TEntity> GetEnumerator() {
            return ((IEnumerable<TEntity>)_entities).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken()) {
            return ((IAsyncEnumerable<TEntity>)_entities).GetAsyncEnumerator(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id) {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllIncludingAsync(Expression<Func<TEntity, object>> includeProperty) {
            return await _entities.Include(includeProperty).ToListAsync();
        }

        public async Task<TEntity> GetByIdIncludingAsync(int id, Expression<Func<TEntity, object>> includeProperty) {
            return await _entities.Where(e => e.Id == id).Include(includeProperty).SingleOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity) {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(TEntity entity) {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity) {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
