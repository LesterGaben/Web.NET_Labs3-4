using HospitalRegistrySystem.BLL.DTOs.Patient;

namespace HospitalRegistrySystem.BLL.Services.Interfaces
{
    public interface IPatientService {
        public Task<IEnumerable<PatientDTO>> GetAllAsync();
        public Task<PatientDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(CreateUpdatePatientDTO dto);
        public Task<PatientDTO> UpdateAsync(int id, CreateUpdatePatientDTO dto);
        public Task DeleteAsync(int id);
    }
}
