using Microsoft.AspNetCore.Mvc;
using ClinicManagementSystem.Server.Models;
using ClinicManagementSystem.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("clinics")]
        public async Task<ActionResult<IEnumerable<Clinic>>> GetClinics()
        {
            var clinics = await _adminService.GetClinicsAsync();
            return Ok(clinics);
        }

        [HttpPost("clinics")]
        public async Task<ActionResult<Clinic>> AddClinic([FromBody] Clinic clinic)
        {
            if (clinic == null)
            {
                return BadRequest("Clinic data is null.");
            }

            Clinic createdClinic = await _adminService.AddClinicAsync(clinic);
            return CreatedAtAction(nameof(GetClinics), new { id = createdClinic.ClinicId }, createdClinic);
        }

        [HttpPut("clinics/{id}")]
        public async Task<IActionResult> UpdateClinic(int id, [FromBody] Clinic clinic)
        {
            if (id != clinic.ClinicId)
            {
                return BadRequest("Clinic ID mismatch.");
            }

            await _adminService.UpdateClinicAsync(clinic);
            return NoContent();
        }

        [HttpDelete("clinics/{id}")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            await _adminService.DeleteClinicAsync(id);
            return NoContent();
        }

        //[HttpGet("users")]
        //public async Task<ActionResult<IEnumerable<Admin>>> GetUsers()
        //{
        //    var users = await _adminService.GetUsersAsync();
        //    return Ok(users);
        //}

        //[HttpPost("users")]
        //public async Task<ActionResult<Admin>> AddUser([FromBody] Admin admin)
        //{
        //    if (admin == null)
        //    {
        //        return BadRequest("User data is null.");
        //    }

        //    var createdUser = await _adminService.AddUserAsync(admin);
        //    return CreatedAtAction(nameof(GetUsers), new { id = createdUser.AdminId }, createdUser);
        //}

        //[HttpPut("users/{id}")]
        //public async Task<IActionResult> UpdateUser(int id, [FromBody] Admin admin)
        //{
        //    if (id != admin.AdminId)
        //    {
        //        return BadRequest("User ID mismatch.");
        //    }

        //    await _adminService.UpdateUserAsync(admin);
        //    return NoContent();
        //}

        //[HttpDelete("users/{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    await _adminService.DeleteUserAsync(id);
        //    return NoContent();
        //}
    }
}