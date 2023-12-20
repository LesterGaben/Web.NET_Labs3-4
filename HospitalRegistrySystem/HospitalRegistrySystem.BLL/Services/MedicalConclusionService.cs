using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs.MedicalConclusion;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services
{
    public class MedicalConclusionService : IMedicalConclusionService {
        private readonly IGenericRepository<MedicalConclusion> _repository;
        private readonly IMapper _mapper;

        public MedicalConclusionService(IGenericRepository<MedicalConclusion> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicalConclusionDTO>> GetAllAsync() {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicalConclusionDTO>>(entities);
        }

        public async Task<MedicalConclusionDTO> GetByIdAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MedicalConclusionDTO>(entity);
        }

        public async Task<int> CreateAsync(CreateMedicalConclusionDTO dto) {
            var entity = _mapper.Map<MedicalConclusion>(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<MedicalConclusionDTO> UpdateAsync(int id, UpdateMedicalConclusionDTO dto) {
            var entity = await _repository.GetByIdAsync(id);
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<MedicalConclusionDTO>(entity);
        }

        public async Task DeleteAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
