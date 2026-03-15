using MedicalprojAsp.netcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalprojAsp.netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public AdminController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("Doctors")]
        public IActionResult Getdoctors()
        {
            return Ok(_appDbContext.Doctors.ToList());
        }

        [HttpPut("Approve-Doctor/{id}")]

        public IActionResult Putdoctors(int id)
        {
            var doctor = _appDbContext.Doctors.Find(id);
            if (doctor== null)
            {
                return NotFound(" Doctor Appointment failed");
            }
            doctor.isApproved = true;
            _appDbContext.SaveChanges();
            return Ok(doctor + " Doctor Appointment Sucessfully");
        }

        [HttpDelete("Delete-Doctor/{id}")]
        
        public IActionResult Deletedoctor(int id)
        {
            var doctor = _appDbContext.Doctors.Find(id);
            if (doctor != null)
            {
                return NotFound("Doctor Not Found");
            }
            _appDbContext.Remove(doctor);
            _appDbContext.SaveChanges();
            return Ok("Doctor Rejected and Removed");
        }

        [HttpGet("patients")]

        public IActionResult Getpatients()
        {
            return Ok(_appDbContext.Patients.ToList());
        }

        [HttpGet("Appointments")]

        public IActionResult GetAppoinments()
        {
            return Ok(_appDbContext.Appoinments.ToList());
        }
    }
}
