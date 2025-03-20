using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Server.Models
{
    public class Receptionist
    {
        [Key]
        public int ReceptionistId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public int ClinicId { get; set; }
        
        // Navigation property
        public virtual Clinic Clinic { get; set; }
    }
}