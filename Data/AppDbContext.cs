<<<<<<< HEAD
﻿using MedicalprojAsp.netcore.Model;
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
=======
﻿using MedicalprojAsp.netcore.Models;
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
>>>>>>> Patient
    }
}
