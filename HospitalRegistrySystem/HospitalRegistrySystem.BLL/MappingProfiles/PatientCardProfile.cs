using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs.PatientCard;
using HospitalRegistrySystem.DAL.Entities;

namespace HospitalRegistrySystem.BLL.MappingProfiles {
    public class PatientCardProfile : Profile {
        public PatientCardProfile() {
            CreateMap<PatientCard, PatientCardDTO>()
                .ForMember(dto => dto.PatientCardId, opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dest => dest.MedicalConclusions, opt => opt.MapFrom(src => src.MedicalConclusions));
            CreateMap<PatientCardDTO, PatientCard>();
            CreateMap<CreatePatientCardDTO, PatientCard>();
        }
    }
}
