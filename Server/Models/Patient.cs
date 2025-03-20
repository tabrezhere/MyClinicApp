using System;

namespace ClinicManagementSystem.Server.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string BPReading { get; set; }
        public bool DiabetesStatus { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int ClinicId { get; set; }
    }
}