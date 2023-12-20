namespace HospitalRegistrySystem.Common.DTOs.Patient {
    public class CreateUpdatePatientDTO {
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
