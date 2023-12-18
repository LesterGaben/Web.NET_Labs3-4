using Microsoft.AspNetCore.Mvc;
using HospitalRegistrySystem.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalRegistrySystem.API.Controllers {
    
    [ApiController]
    [Route("pacients")]
    public class PacientController : ControllerBase {

        //private readonly IPacientService _pacientService;

        public PacientController() { }

        [HttpGet]
        public IActionResult GetPacient() {
            return Ok("Artem");
            
        }
    }
}
