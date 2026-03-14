using System.ComponentModel.DataAnnotations;

namespace MedicalprojAsp.netcore.Model
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}
