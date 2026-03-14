using MedicalprojAsp.netcore.Data;
using MedicalprojAsp.netcore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalprojAsp.netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoinmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppoinmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("Book Appoinment")]
        public IActionResult book(Appoinment book)
        {
            book.status = "Pending";
            _context.Add(book);
            _context.SaveChanges();
            return Ok("Appoinment Booked sucessfully");
        }

        [HttpPut("Update/{id}")]
        public IActionResult Updatestatus(int id , string status) 
        {
            var appoinment = _context.Appoinments.Find(id);
            if (appoinment == null)
            {
                return NotFound("appoinment Not Found");
            }
             appoinment.status = status;
            _context.SaveChanges();
            return Ok("Appoinment status updated");
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var appoinment = _context.Appoinments.Find(id);
            if (appoinment == null)
            {
                return NotFound("Appoinment Not Found");
            }
            _context.Remove(appoinment);
            _context.SaveChanges();
            return Ok("Appoinment sucessfully deleted");
        }

        [HttpGet("PatientId")]

        public IActionResult GetPatient(int patientId)
        {
            var patient = _context.Patients.Where(x => x.PatientId == patientId).ToList();

            if (patient == null)
            {
                return NotFound("patients not found");
            }
            return Ok(patient);
        }
        [HttpGet("DoctorId")]

        public IActionResult GetDoctor(int doctorId)
        {
            var Doctor = _context.Doctors.Where(x => x.DoctorID == doctorId).ToList();
            if (Doctor == null)
            {
                return NotFound("Doctor not found");
            }
            return Ok(Doctor);
        }


    }
}