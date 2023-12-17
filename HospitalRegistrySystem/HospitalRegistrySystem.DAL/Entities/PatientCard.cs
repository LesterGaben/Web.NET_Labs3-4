using HospitalRegistrySystem.DAL.Entities.Abstract;


namespace HospitalRegistrySystem.DAL.Entities {
    public class PatientCard : BaseEntity {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<MedicalConclusion> MedicalConclusions { get; set; }

    }
}
