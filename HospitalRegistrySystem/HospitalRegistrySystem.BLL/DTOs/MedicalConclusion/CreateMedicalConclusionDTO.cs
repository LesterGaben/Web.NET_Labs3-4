namespace HospitalRegistrySystem.BLL.DTOs.MedicalConclusion {
    public class CreateMedicalConclusionDTO {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int? PatientCardId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
