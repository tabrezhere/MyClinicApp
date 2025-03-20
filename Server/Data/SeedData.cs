using System;
using System.Collections.Generic;
using System.Linq;
using ClinicManagementSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Server.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if any clinics exist
            if (context.Clinics.Any())
            {
                return;   // DB has been seeded
            }

            var clinics = new List<Clinic>
            {
                new Clinic { ClinicName = "Health Clinic", Address = "123 Health St", ContactNumber = "123-456-7890" },
                new Clinic { ClinicName = "Wellness Center", Address = "456 Wellness Ave", ContactNumber = "987-654-3210" }
            };

            context.Clinics.AddRange(clinics);
            context.SaveChanges();

            var doctors = new List<Doctor>
            {
                new Doctor { Name = "Dr. Smith", Specialization = "Cardiology", Address = "789 Doctor Rd", ClinicId = clinics[0].ClinicId },
                new Doctor { Name = "Dr. Jones", Specialization = "Pediatrics", Address = "321 Doctor Blvd", ClinicId = clinics[1].ClinicId }
            };

            context.Doctors.AddRange(doctors);
            context.SaveChanges();

            var receptionists = new List<Receptionist>
            {
                new Receptionist { Name = "Alice", ClinicId = clinics[0].ClinicId },
                new Receptionist { Name = "Bob", ClinicId = clinics[1].ClinicId }
            };

            context.Receptionists.AddRange(receptionists);
            context.SaveChanges();

            var patients = new List<Patient>
            {
                new Patient { Name = "John Doe", Age = 30, Gender = "Male", MobileNumber = "555-1234", BPReading = "120/80", DiabetesStatus = false, DateOfRegistration = DateTime.Now, ClinicId = clinics[0].ClinicId },
                new Patient { Name = "Jane Doe", Age = 25, Gender = "Female", MobileNumber = "555-5678", BPReading = "130/85", DiabetesStatus = true, DateOfRegistration = DateTime.Now, ClinicId = clinics[1].ClinicId }
            };

            context.Patients.AddRange(patients);
            context.SaveChanges();
        }
    }
}