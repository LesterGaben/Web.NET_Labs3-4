using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs.PatientCard;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services
{
    public class PatientCardService : IPatientCardService {
        private readonly IGenericRepository<PatientCard> _repository;
        private readonly IMapper _mapper;

        public PatientCardService(IGenericRepository<PatientCard> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientCardDTO>> GetAllAsync() {
            var entities = await _repository.GetAllIncludingAsync(pc => pc.MedicalConclusions);
            return _mapper.Map<IEnumerable<PatientCardDTO>>(entities);
        }

        public async Task<PatientCardDTO> GetByIdAsync(int id) {
            var entity = await _repository.GetByIdIncludingAsync(id, pc => pc.MedicalConclusions);
            return _mapper.Map<PatientCardDTO>(entity);
        }

        public async Task<int> CreateAsync(CreatePatientCardDTO dto) {
            var entity = _mapper.Map<PatientCard>(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
