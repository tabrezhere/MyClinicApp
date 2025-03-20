using System;

namespace ClinicManagementSystem.Shared.DTOs
{
    public class ClinicDto
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }
}