using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs.Appointment;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;

namespace HospitalRegistrySystem.BLL.Services
{
    public class AppointmentService : IAppointmentService {
        private readonly IGenericRepository<Appointment> _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IGenericRepository<Appointment> repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAsync() {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AppointmentDTO>>(entities);
        }

        public async Task<AppointmentDTO> GetByIdAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<AppointmentDTO>(entity);
        }

        public async Task<int> CreateAsync(CreateUpdateAppointmentDTO dto) {
            var entity = _mapper.Map<Appointment>(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<AppointmentDTO> UpdateAsync(int id, CreateUpdateAppointmentDTO dto) {
            var entity = await _repository.GetByIdAsync(id);
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<AppointmentDTO>(entity);
        }

        public async Task DeleteAsync(int id) {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
    }
}
