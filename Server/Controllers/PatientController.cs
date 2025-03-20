using Microsoft.AspNetCore.Mvc;
using ClinicManagementSystem.Server.Models;
using ClinicManagementSystem.Server.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ClinicManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient data is null.");
            }

            var result = await _patientService.AddPatientAsync(patient);
            if (result.PatientId > 0)
            {
                return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error registering patient.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients(int clinicid)
        {
            var patients = await _patientService.GetAllPatientsAsync(clinicid);
           
            return Ok(patients);
        }
    }

}