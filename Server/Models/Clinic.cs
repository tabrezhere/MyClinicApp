using ClinicManagementSystem.Server.Models;

public class Clinic
{
    public int ClinicId { get; set; } // Primary Key
    public string ClinicName { get; set; } // Name of the clinic
    public string Address { get; set; } // Address of the clinic
    public string ContactNumber { get; set; } // Contact number of the clinic
    public ICollection<Doctor> Doctors { get; set; } // Doctors assigned to the clinic
    public ICollection<Receptionist> Receptionists { get; set; } // Receptionists assigned to the clinic
}