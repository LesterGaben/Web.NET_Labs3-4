using HospitalRegistrySystem.DAL.Entities.Abstract;

namespace HospitalRegistrySystem.DAL.Entities {
    public class Patient : BaseEntity {
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<MedicalConclusion> MedicalConclusions { get; set; }
        public PatientCard PatientCard { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
