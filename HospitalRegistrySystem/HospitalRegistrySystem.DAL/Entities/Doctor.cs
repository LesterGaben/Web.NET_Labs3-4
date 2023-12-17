using HospitalRegistrySystem.DAL.Entities.Abstract;

namespace HospitalRegistrySystem.DAL.Entities {
    public class Doctor : BaseEntity {
        public string FullName { get; set; }
        public string Speciality { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalConclusion> MedicalConclusions { get; set; }
    }
}
