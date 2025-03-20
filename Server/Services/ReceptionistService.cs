using ClinicManagementSystem.Server.Data;
using ClinicManagementSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Server.Services
{
    public class ReceptionistService
    {
        private readonly ApplicationDbContext _context;

        public ReceptionistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Receptionist> GetReceptionistByIdAsync(int id)
        {
            return await _context.Receptionists.FindAsync(id);
        }

        public async Task<List<Receptionist>> GetAllReceptionistsAsync()
        {
            return await _context.Receptionists.ToListAsync();
        }

        public async Task AddReceptionistAsync(Receptionist receptionist)
        {
            _context.Receptionists.Add(receptionist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReceptionistAsync(Receptionist receptionist)
        {
            _context.Receptionists.Update(receptionist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceptionistAsync(int id)
        {
            var receptionist = await GetReceptionistByIdAsync(id);
            if (receptionist != null)
            {
                _context.Receptionists.Remove(receptionist);
                await _context.SaveChangesAsync();
            }
        }
    }
}