using HospitalRegistrySystem.BLL.DTOs;

namespace HospitalRegistrySystem.BLL.Services.Interfaces {
    public interface IPatientCardService {
        public Task<IEnumerable<PatientCardDTO>> GetAllAsync();
        public Task<PatientCardDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(PatientCardDTO dto);
        public Task<PatientCardDTO> UpdateAsync(PatientCardDTO dto);
        public Task DeleteAsync(int id);
    }
}
