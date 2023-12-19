namespace HospitalRegistrySystem.BLL.DTOs.Appointment
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
