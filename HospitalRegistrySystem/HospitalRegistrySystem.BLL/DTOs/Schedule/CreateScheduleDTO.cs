namespace HospitalRegistrySystem.BLL.DTOs.Schedule {
    public class CreateScheduleDTO {
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsAviable { get; set; }
    }
}
