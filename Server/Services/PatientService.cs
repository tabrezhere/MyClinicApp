using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagementSystem.Server.Data;
using ClinicManagementSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Server.Services
{
    public class PatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllPatientsAsync(int clinicId)
        {
            return await _context.Patients
                .Where(p => p.ClinicId == clinicId)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _context.Patients.FindAsync(patientId);
        }

        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task DeletePatientAsync(int patientId)
        {
            var patient = await _context.Patients.FindAsync(patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}