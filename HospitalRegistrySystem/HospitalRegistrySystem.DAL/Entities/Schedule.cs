using HospitalRegistrySystem.DAL.Entities.Abstract;

namespace HospitalRegistrySystem.DAL.Entities {
    public class Schedule : BaseEntity {
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsAviable { get; set; }
        public Doctor Doctor { get; set; }

    }
}
