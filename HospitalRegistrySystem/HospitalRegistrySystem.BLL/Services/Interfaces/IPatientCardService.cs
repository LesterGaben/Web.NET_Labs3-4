using HospitalRegistrySystem.BLL.DTOs.PatientCard;

namespace HospitalRegistrySystem.BLL.Services.Interfaces
{
    public interface IPatientCardService {
        public Task<IEnumerable<PatientCardDTO>> GetAllAsync();
        public Task<PatientCardDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(CreatePatientCardDTO dto);
        public Task DeleteAsync(int id);
    }
}
