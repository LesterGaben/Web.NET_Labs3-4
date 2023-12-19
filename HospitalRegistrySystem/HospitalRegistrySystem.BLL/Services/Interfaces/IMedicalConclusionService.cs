using HospitalRegistrySystem.BLL.DTOs;

namespace HospitalRegistrySystem.BLL.Services.Interfaces {
    public interface IMedicalConclusionService {
        public Task<IEnumerable<MedicalConclusionDTO>> GetAllAsync();
        public Task<MedicalConclusionDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(MedicalConclusionDTO dto);
        public Task<MedicalConclusionDTO> UpdateAsync(MedicalConclusionDTO dto);
        public Task DeleteAsync(int id);
    }
}
