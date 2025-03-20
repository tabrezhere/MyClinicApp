public class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string Address { get; set; }
    public int ClinicId { get; set; }

    // Navigation property
    public virtual Clinic Clinic { get; set; }
}