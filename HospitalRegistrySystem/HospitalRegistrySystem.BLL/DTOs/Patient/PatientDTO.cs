﻿namespace HospitalRegistrySystem.BLL.DTOs.Patient
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
