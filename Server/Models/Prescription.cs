using ClinicManagementSystem.Server.Models;

public class Prescription
{
    public int PrescriptionId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public string TabletName { get; set; }
    public int Quantity { get; set; }
    public int TimesPerDay { get; set; }
    public DateTime DatePrescribed { get; set; }

    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
}