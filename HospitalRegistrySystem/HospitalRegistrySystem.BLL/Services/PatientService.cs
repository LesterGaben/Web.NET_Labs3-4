using AutoMapper;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.Common.DTOs.Patient;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services {
    public class PatientService: IPatientService {

        private readonly IGenericRepository<Patient> _repository;
        private readonly IMapper _mapper;

        public PatientService(IGenericRepository<Patient> repository, IMapper mapper)  {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllAsync() {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(entities);
        }

        public async Task<PatientDTO> GetByIdAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<PatientDTO>(entity);
        }

        public async Task<int> CreateAsync(CreateUpdatePatientDTO dto) {
            var entity = _mapper.Map<Patient>(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<PatientDTO> UpdateAsync(int id, CreateUpdatePatientDTO dto) {
            var entity = await _repository.GetByIdAsync(id);
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<PatientDTO>(entity);
        }

        public async Task DeleteAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
