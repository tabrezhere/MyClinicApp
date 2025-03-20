using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagementSystem.Server.Data;
using ClinicManagementSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Server.Services
{
    public class DoctorService
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _context.Doctors.FindAsync(doctorId);
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}