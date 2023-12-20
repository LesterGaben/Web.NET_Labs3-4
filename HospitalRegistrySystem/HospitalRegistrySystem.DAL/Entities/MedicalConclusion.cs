using HospitalRegistrySystem.DAL.Entities.Abstract;


namespace HospitalRegistrySystem.DAL.Entities {
    public class MedicalConclusion : BaseEntity {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int? PatientCardId { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public PatientCard PatientCard { get; set; }
    }
}
