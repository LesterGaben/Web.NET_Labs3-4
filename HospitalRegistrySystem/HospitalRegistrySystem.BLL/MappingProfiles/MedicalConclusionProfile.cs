using AutoMapper;
using HospitalRegistrySystem.BLL.DTOs.MedicalConclusion;
using HospitalRegistrySystem.DAL.Entities;

namespace HospitalRegistrySystem.BLL.MappingProfiles {
    public class MedicalConclusionProfile : Profile {
        public MedicalConclusionProfile() {
            CreateMap<MedicalConclusion, MedicalConclusionDTO>()
                .ForMember(dto => dto.MedicalConclusionId, opt => opt.MapFrom(entity => entity.Id));
            CreateMap<MedicalConclusionDTO, MedicalConclusion>();
            CreateMap<CreateMedicalConclusionDTO, MedicalConclusion>();
            CreateMap<UpdateMedicalConclusionDTO, MedicalConclusion>();
        }
    }
}
