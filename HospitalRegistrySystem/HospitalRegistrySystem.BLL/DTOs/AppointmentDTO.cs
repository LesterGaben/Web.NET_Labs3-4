namespace HospitalRegistrySystem.BLL.DTOs {
    public class AppointmentDTO {
        public string DoctorFullName { get; set; } = string.Empty;
        public string PatientFullName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
