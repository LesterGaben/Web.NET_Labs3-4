using HospitalRegistrySystem.BLL.DTOs.MedicalConclusion;

namespace HospitalRegistrySystem.BLL.DTOs.PatientCard {
    public class PatientCardDTO {
        public int PatientCardId { get; set; }
        public int PatientId { get; set; }
        public List<MedicalConclusionDTO> MedicalConclusions { get; set; }
    }
}
