using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagementSystem.Server.Models;
using ClinicManagementSystem.Server.Services;
using Microsoft.AspNetCore.Authorization;

namespace ClinicManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        //{
        //    var doctors = await _doctorService.GetAllDoctorsAsync();
        //    return Ok(doctors);
        //}

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("This is an admin-only endpoint.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor(Doctor doctor)
        {

            if (doctor == null)
            {
                return BadRequest("doctor data is null.");
            }

            var createdDoctor = await _doctorService.AddDoctorAsync(doctor);
            if (createdDoctor.DoctorId > 0)
            {
                return CreatedAtAction(nameof(GetDoctor), new { id = createdDoctor.DoctorId }, createdDoctor);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error registering patient.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }

            await _doctorService.UpdateDoctorAsync(doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}