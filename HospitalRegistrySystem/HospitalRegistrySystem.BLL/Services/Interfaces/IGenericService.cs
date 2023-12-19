namespace HospitalRegistrySystem.BLL.Services.Interfaces {
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class {
        public Task<IEnumerable<TDto>> GetAllAsync();
        public Task<TDto> GetAsync(int id);
        public Task<TDto> CreateAsync(TDto dto);
        public Task<TDto> UpdateAsync(TDto dto);
        public Task DeleteAsync(int id);
    }
}
