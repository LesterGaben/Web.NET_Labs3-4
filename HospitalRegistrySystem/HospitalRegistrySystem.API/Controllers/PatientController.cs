using Microsoft.AspNetCore.Mvc;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.Common.DTOs.Patient;


namespace HospitalRegistrySystem.API.Controllers {

    [ApiController]
    [Route("patients")]
    public class PatientController : ControllerBase {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) {
            _patientService = patientService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _patientService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            return Ok(await _patientService.GetByIdAsync(id));
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdatePatientDTO patient) {
            return Ok(await _patientService.CreateAsync(patient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, CreateUpdatePatientDTO patient) {
            return Ok(await _patientService.UpdateAsync(id, patient));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _patientService.DeleteAsync(id);
            return NoContent();
        }

    }
}
