using AutoMapper;
using HospitalRegistrySystem.Common.DTOs.Appointment;
using HospitalRegistrySystem.DAL.Entities;

namespace HospitalRegistrySystem.BLL.MappingProfiles {
    public class AppointmentProfile : Profile {
        public AppointmentProfile() {
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dto => dto.AppointmentId, opt => opt.MapFrom(entity => entity.Id));
            CreateMap<AppointmentDTO, Appointment>();
            CreateMap<CreateUpdateAppointmentDTO, Appointment>();
        }
    }

}
