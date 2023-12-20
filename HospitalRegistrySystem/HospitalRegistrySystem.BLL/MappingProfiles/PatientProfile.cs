using AutoMapper;
using HospitalRegistrySystem.Common.DTOs.Patient;
using HospitalRegistrySystem.DAL.Entities;

namespace HospitalRegistrySystem.BLL.MappingProfiles {
    public class PatientProfile : Profile {
        public PatientProfile() {
            CreateMap<Patient, PatientDTO>()
                .ForMember(dto => dto.PatientId, opt => opt.MapFrom(entity => entity.Id));
            CreateMap<PatientDTO, Patient>();
            CreateMap<CreateUpdatePatientDTO, Patient>();
        }
    }

}
