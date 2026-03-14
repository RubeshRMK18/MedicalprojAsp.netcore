using MedicalprojAsp.netcore.Data;
using MedicalprojAsp.netcore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalprojAsp.netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        public readonly AppDbContext Context;
        public DoctorController(AppDbContext context)
        {
            Context = context; 
        }

        [HttpPost("register")]
        public IActionResult RegisterDoctor(Doctor doctor)
        {
            doctor.isApproved = false;
            Context.Doctors.Add(doctor);
            Context.SaveChanges();

            return Ok("Registration Sucessful");
        }

        [HttpGet]
        public IActionResult GetDoctor()
        {
            //Fetch all the data from doctors list.
            var Doctors = Context.Doctors.Where(x => x.isApproved == true).ToList(); 
            return Ok(Doctors);
        }

        [HttpPost("Add-Schedule")]
        public IActionResult Addschedule(DoctorSchedule doctorSchedule)
        {
            Context.DoctorSchedules.Add(doctorSchedule);
            Context.SaveChanges();
            return Ok("Schedule Sucessfully Added");
        }

        [HttpGet("schedule/doctorID")]

        public IActionResult GetDoctorSchedule(int doctorid)
        {
            Context.DoctorSchedules.Where(x => x.DoctorID == doctorid).ToList();
            Context.SaveChanges();
            return Ok("Sucessfully Created");
        }
    }
}
