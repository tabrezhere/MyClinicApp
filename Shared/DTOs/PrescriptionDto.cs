using System;

namespace Shared.DTOs
{
    public class PrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TabletName { get; set; }
        public int Quantity { get; set; }
        public int TimesPerDay { get; set; }
        public DateTime DatePrescribed { get; set; }
    }
}