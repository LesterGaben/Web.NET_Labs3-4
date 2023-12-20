namespace HospitalRegistrySystem.Common.DTOs.Schedule {
    public class ScheduleDTO {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsAviable { get; set; }
    }
}
