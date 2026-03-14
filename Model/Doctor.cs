using System.ComponentModel.DataAnnotations;

namespace MedicalprojAsp.netcore.Model
{
    
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [Required]
        public string DoctorName { get; set; }
        public string Specialization { get; set; }

        public string Email { get; set; }

        public string password { get; set; }

        public bool isApproved { get; set; }

    }
}
