using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.Common.DTOs.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace HospitalRegistrySystem.API.Controllers {

    [ApiController]
    [Route("doctors")]
    public class DoctorController : Controller {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService) {
            _doctorService = doctorService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _doctorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            return Ok(await _doctorService.GetByIdAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateDoctorDTO doctor) {
            return Ok(await _doctorService.CreateAsync(doctor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, CreateUpdateDoctorDTO doctor) {
            return Ok(await _doctorService.UpdateAsync(id, doctor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _doctorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
