using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs.Doctor;
using HospitalRegistrySystem.DAL.Entities;

namespace HospitalRegistrySystem.BLL.MappingProfiles {
    public class DoctorProfile : Profile {
        public DoctorProfile() {
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dto => dto.DoctorId, opt => opt.MapFrom(entity => entity.Id));
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<CreateUpdateDoctorDTO, Doctor>();
        }
    }
}
