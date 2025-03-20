using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagementSystem.Server.Data;
using ClinicManagementSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Server.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clinic>> GetClinicsAsync()
        {
            return await _context.Clinics.ToListAsync();
        }

        public async Task<Clinic> GetClinicByIdAsync(int clinicId)
        {
            return await _context.Clinics.FindAsync(clinicId);
        }

        public async Task<Clinic> AddClinicAsync(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();
            return clinic;
           
        }

        public async Task UpdateClinicAsync(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClinicAsync(int clinicId)
        {
            var clinic = await _context.Clinics.FindAsync(clinicId);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Admin>> GetAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> GetAdminByIdAsync(int adminId)
        {
            return await _context.Admins.FindAsync(adminId);
        }

        public async Task AddAdminAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdminAsync(int adminId)
        {
            var admin = await _context.Admins.FindAsync(adminId);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }
    }
}