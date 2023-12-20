using AutoMapper;
using HospitalRegistrySystem.Common.DTOs.Schedule;
using HospitalRegistrySystem.DAL.Entities;

namespace HospitalRegistrySystem.BLL.MappingProfiles {
    public class ScheduleProfile : Profile {
        public ScheduleProfile() {
            CreateMap<Schedule, ScheduleDTO>()
                .ForMember(dto => dto.ScheduleId, opt => opt.MapFrom(entity => entity.Id));
            CreateMap<ScheduleDTO, Schedule>();
            CreateMap<CreateScheduleDTO, Schedule>();
            CreateMap<UpdateScheduleDTO, Schedule>();
        }
    }
}
