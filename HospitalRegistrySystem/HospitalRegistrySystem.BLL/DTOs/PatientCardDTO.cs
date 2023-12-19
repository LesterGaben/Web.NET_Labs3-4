namespace HospitalRegistrySystem.BLL.DTOs {
    public class PatientCardDTO {
        public string PatientFullName { get; set; } = string.Empty;
        public List<MedicalConclusionDTO> MedicalConclusions { get; set; }
    }
}
