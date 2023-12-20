using AutoMapper;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.Common.DTOs.Schedule;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services {
    public class ScheduleService : IScheduleService {
        private readonly IGenericRepository<Schedule> _repository;
        private readonly IMapper _mapper;

        public ScheduleService(IGenericRepository<Schedule> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllAsync() {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ScheduleDTO>>(entities);
        }

        public async Task<ScheduleDTO> GetByIdAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ScheduleDTO>(entity);
        }

        public async Task<int> CreateAsync(CreateScheduleDTO dto) {
            var entity = _mapper.Map<Schedule>(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<ScheduleDTO> UpdateAsync(int id, UpdateScheduleDTO dto) {
            var entity = await _repository.GetByIdAsync(id);
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<ScheduleDTO>(entity);
        }

        public async Task DeleteAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
