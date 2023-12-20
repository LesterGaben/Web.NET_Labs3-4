using HospitalRegistrySystem.Common.DTOs.MedicalConclusion;

namespace HospitalRegistrySystem.Common.DTOs.PatientCard {
    public class PatientCardDTO {
        public int PatientCardId { get; set; }
        public int PatientId { get; set; }
        public List<MedicalConclusionDTO> MedicalConclusions { get; set; }
    }
}
