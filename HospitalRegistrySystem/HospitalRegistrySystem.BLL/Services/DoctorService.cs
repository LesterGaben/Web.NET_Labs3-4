using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs.Doctor;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services
{
    public class DoctorService : IDoctorService {
        private readonly IGenericRepository<Doctor> _repository;
        private readonly IMapper _mapper;

        public DoctorService(IGenericRepository<Doctor> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllAsync() {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDTO>>(entities);
        }

        public async Task<DoctorDTO> GetByIdAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<DoctorDTO>(entity);
        }

        public async Task<int> CreateAsync(CreateUpdateDoctorDTO dto) {
            var entity = _mapper.Map<Doctor>(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<DoctorDTO> UpdateAsync(int id, CreateUpdateDoctorDTO dto) {
            var entity = await _repository.GetByIdAsync(id);

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<DoctorDTO>(entity);
        }

        public async Task DeleteAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
