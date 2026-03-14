using System.ComponentModel.DataAnnotations;

namespace MedicalprojAsp.netcore.Model
{
    public class DoctorSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int DoctorID { get; set; }

        public string AvailabilityDay { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; } 
    }
}
