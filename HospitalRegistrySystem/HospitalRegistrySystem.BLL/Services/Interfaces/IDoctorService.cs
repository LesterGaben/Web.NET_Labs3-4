using HospitalRegistrySystem.BLL.DTOs.Doctor;

namespace HospitalRegistrySystem.BLL.Services.Interfaces
{
    public interface IDoctorService {
        public Task<IEnumerable<DoctorDTO>> GetAllAsync();
        public Task<DoctorDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(CreateUpdateDoctorDTO dto);
        public Task<DoctorDTO> UpdateAsync(int id, CreateUpdateDoctorDTO dto);
        public Task DeleteAsync(int id);
    }
}
