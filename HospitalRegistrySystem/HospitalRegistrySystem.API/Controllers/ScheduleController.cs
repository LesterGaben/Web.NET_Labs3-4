using HospitalRegistrySystem.BLL.DTOs.Schedule;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalRegistrySystem.API.Controllers {

    [ApiController]
    [Route("schedules")]
    public class ScheduleController : Controller {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService) {
            _scheduleService = scheduleService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Ok(await _scheduleService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            return Ok(await _scheduleService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleDTO schedule) {
            return Ok(await _scheduleService.CreateAsync(schedule));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateScheduleDTO schedule) {
            return Ok(await _scheduleService.UpdateAsync(id, schedule));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _scheduleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
