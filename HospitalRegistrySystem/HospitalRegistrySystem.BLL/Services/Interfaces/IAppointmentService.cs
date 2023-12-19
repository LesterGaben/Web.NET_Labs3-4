using HospitalRegistrySystem.BLL.DTOs.Appointment;

namespace HospitalRegistrySystem.BLL.Services.Interfaces
{
    public interface IAppointmentService {
        public Task<IEnumerable<AppointmentDTO>> GetAllAsync();
        public Task<AppointmentDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(CreateUpdateAppointmentDTO dto);
        public Task<AppointmentDTO> UpdateAsync(int id, CreateUpdateAppointmentDTO dto);
        public Task DeleteAsync(int id);
    }
}
