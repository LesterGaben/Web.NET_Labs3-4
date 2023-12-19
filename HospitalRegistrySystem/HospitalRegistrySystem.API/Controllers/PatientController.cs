using Microsoft.AspNetCore.Mvc;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.BLL.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalRegistrySystem.API.Controllers {
    
    [ApiController]
    [Route("pacients")]
    public class PatientController : ControllerBase {

        private readonly IGenericService<Patient, PatientDTO> _patientService;

        public PatientController(IGenericService<Patient, PatientDTO> patientService) {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetPacient() {
            return Ok("Artem");
            
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientDTO patient) {
            return Ok(await _patientService.CreateAsync(patient));
        }
    }
}
