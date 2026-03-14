using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalprojAsp.netcore.Model
{
    public class Appoinment
    {
        public int AppoinmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public string status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}
