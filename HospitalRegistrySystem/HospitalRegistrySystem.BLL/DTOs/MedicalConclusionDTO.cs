namespace HospitalRegistrySystem.BLL.DTOs {
    public class MedicalConclusionDTO {
        public string DoctorFullName { get; set; } = string.Empty;
        public string PatientFullName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
