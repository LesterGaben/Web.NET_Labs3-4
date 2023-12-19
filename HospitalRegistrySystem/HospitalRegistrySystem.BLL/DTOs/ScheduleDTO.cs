namespace HospitalRegistrySystem.BLL.DTOs {
    public class ScheduleDTO {
        public string DoctorFullName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public bool IsAviable { get; set; }
    }
}
