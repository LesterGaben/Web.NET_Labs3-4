using HospitalRegistrySystem.BLL.DTOs.Appointment;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalRegistrySystem.API.Controllers {

    [ApiController]
    [Route("appointments")]
    public class AppointmentController : Controller {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService) {
            _appointmentService = appointmentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _appointmentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            return Ok(await _appointmentService.GetByIdAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateAppointmentDTO appointment) {
            return Ok(await _appointmentService.CreateAsync(appointment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, CreateUpdateAppointmentDTO appointment) {
            return Ok(await _appointmentService.UpdateAsync(id, appointment));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _appointmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
