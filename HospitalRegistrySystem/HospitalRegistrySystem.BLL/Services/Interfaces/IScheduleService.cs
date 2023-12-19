using HospitalRegistrySystem.BLL.DTOs;

namespace HospitalRegistrySystem.BLL.Services.Interfaces {
    public interface IScheduleService {
        public Task<IEnumerable<ScheduleDTO>> GetAllAsync();
        public Task<ScheduleDTO> GetByIdAsync(int id);
        public Task<int> CreateAsync(ScheduleDTO dto);
        public Task<ScheduleDTO> UpdateAsync(ScheduleDTO dto);
        public Task DeleteAsync(int id);
    }
}
