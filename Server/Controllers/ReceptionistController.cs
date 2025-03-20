using ClinicManagementSystem.Server.Models;
using ClinicManagementSystem.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly ReceptionistService _receptionistService;

        public ReceptionistController(ReceptionistService receptionistService)
        {
            _receptionistService = receptionistService;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> RegisterPatient([FromBody] Patient patient)
        //{
        //    if (patient == null)
        //    {
        //        return BadRequest("Patient data is null.");
        //    }

        //    var result = await _receptionistService.RegisterPatientAsync(patient);
        //    if (result)
        //    {
        //        return Ok("Patient registered successfully.");
        //    }

        //    return BadRequest("Failed to register patient.");
        //}

        //[HttpGet("patients")]
        //public async Task<IActionResult> GetPatients()
        //{
        //    var patients = await _receptionistService.GetPatientsAsync();
        //    return Ok(patients);
        //}
    }
}