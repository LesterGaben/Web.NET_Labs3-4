using HospitalRegistrySystem.BLL.DTOs.Schedule;

namespace HospitalRegistrySystem.BLL.Services.Interfaces
{
    public interface IScheduleService {
        public Task<IEnumerable<ScheduleDTO>> GetAllAsync();
        public Task<ScheduleDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(CreateScheduleDTO dto);
        public Task<ScheduleDTO> UpdateAsync(int id, UpdateScheduleDTO dto);
        public Task DeleteAsync(int id);
    }
}
