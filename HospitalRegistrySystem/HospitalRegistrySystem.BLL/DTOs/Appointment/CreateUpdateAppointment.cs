namespace HospitalRegistrySystem.BLL.DTOs.Appointment {
    public class CreateUpdateAppointmentDTO {
        public int DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
