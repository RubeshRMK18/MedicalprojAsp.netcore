using MedicalprojAsp.netcore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MedicalprojAsp.netcore.Data
{
    public class AppDbContext:DbContext

    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
