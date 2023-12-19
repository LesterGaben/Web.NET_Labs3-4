using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs;
using HospitalRegistrySystem.BLL.Services.Abstract;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.DAL.Context;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services {
    public class PatientService<TEntity, TDto> : BaseService<TEntity> , IGenericService<TEntity, TDto> where TEntity : Patient where TDto : PatientDTO {

        public PatientService(IGenericRepository<TEntity> repository, IMapper mapper) : base(repository, mapper) {

        }

        public Task<TDto> GetAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<TDto> CreateAsync(TDto dto) {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public Task DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDto>> GetAllAsync() {
            throw new NotImplementedException();
        }

        

        public Task<TDto> UpdateAsync(TDto dto) {
            throw new NotImplementedException();
        }
    }
}
