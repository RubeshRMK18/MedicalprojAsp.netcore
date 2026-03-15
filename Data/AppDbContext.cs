
using MedicalprojAsp.netcore.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalprojAsp.netcore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Database Connection
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appoinment>Appoinments { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
