using HospitalRegistrySystem.BLL.DTOs.PatientCard;
using HospitalRegistrySystem.BLL.Services;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalRegistrySystem.API.Controllers {

    [ApiController]
    [Route("patient-cards")]
    public class PatientCardController : Controller {
        private readonly IPatientCardService _patientCardService;

        public PatientCardController(IPatientCardService patientCardService) {
            _patientCardService = patientCardService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _patientCardService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            return Ok(await _patientCardService.GetByIdAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCardDTO patientcard) {
            return Ok(await _patientCardService.CreateAsync(patientcard));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _patientCardService.DeleteAsync(id);
            return NoContent();
        }
    }
}
