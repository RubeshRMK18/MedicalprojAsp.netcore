using MedicalprojAsp.netcore.Data;
using MedicalprojAsp.netcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedicalprojAsp.netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly AppDbContext _context;

        public PatientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return Ok("Patient Registered Successfully");
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            return Ok(_context.Patients.ToList());
        }
    }
}
