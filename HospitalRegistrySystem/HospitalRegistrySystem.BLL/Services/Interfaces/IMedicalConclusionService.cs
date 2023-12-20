using HospitalRegistrySystem.BLL.DTOs.MedicalConclusion;

namespace HospitalRegistrySystem.BLL.Services.Interfaces
{
    public interface IMedicalConclusionService {
        public Task<IEnumerable<MedicalConclusionDTO>> GetAllAsync();
        public Task<MedicalConclusionDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(CreateMedicalConclusionDTO dto);
        public Task<MedicalConclusionDTO> UpdateAsync(int id, UpdateMedicalConclusionDTO dto);
        public Task DeleteAsync(int id);
    }
}
