using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.Common.DTOs.MedicalConclusion;
using Microsoft.AspNetCore.Mvc;

namespace HospitalRegistrySystem.API.Controllers {

    [ApiController]
    [Route("medical-conclusions")]
    public class MedicalConclusionController : Controller {
        private readonly IMedicalConclusionService _medicalConclusionService;

        public MedicalConclusionController(IMedicalConclusionService medicalConclusionService) {
            _medicalConclusionService = medicalConclusionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _medicalConclusionService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            return Ok(await _medicalConclusionService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMedicalConclusionDTO medicalConclusion) {
            return Ok(await _medicalConclusionService.CreateAsync(medicalConclusion));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateMedicalConclusionDTO medicalConclusion) {
            return Ok(await _medicalConclusionService.UpdateAsync(id, medicalConclusion));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _medicalConclusionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
