using DoctorAppointment.Data;
using DoctorAppointment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DoctorAppointmentDbContext _dbContext;

        public PatientController(DoctorAppointmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var patient = await _dbContext.Patients.ToListAsync();
            if(patient == null || patient.Count == 0) 
            { 
                return NotFound("No Patients Found"); 
            }
            return Ok(patient);
        }

        [HttpGet]
        [Route("id: guid")]
        public async Task<IActionResult> GetAppointment([FromRoute]Guid id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);
            if(patient != null)
            {
                return Ok(patient);
            }
            return NotFound("Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] Patient patientRequest)
        {
            if (ModelState.IsValid)
            {
                patientRequest.Id = Guid.NewGuid();
                await _dbContext.Patients.AddAsync(patientRequest);
                await _dbContext.SaveChangesAsync();

                return Ok(patientRequest);
            }
            //patientRequest.Id = Guid.NewGuid();
            //await _dbContext.Patients.AddAsync(patientRequest);
            //await _dbContext.SaveChangesAsync();
            return BadRequest("Invalid Input");
        }

        [HttpPut]
        [Route("id: guid")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] Guid id, [FromBody] Patient patientRequest)
        {
            var patient = await _dbContext.Patients.FindAsync(id);
            if (patient != null)
            {
                patient.AppointmentDateTime = DateTime.Now;
                patient.PatientNumber = patientRequest.PatientNumber;
                patient.PatientLastName = patientRequest.PatientLastName;
                patient.PatientFirstName = patientRequest.PatientFirstName;
                patient.Address = patientRequest.Address;
                patient.ClinicId = patientRequest.ClinicId;
                patient.NationalCode = patientRequest.NationalCode;
                //patient.IsDeleted = patientRequest.IsDeleted;
                patient.Phone = patientRequest.Phone;
                if (ModelState.IsValid)
                {
                    await _dbContext.SaveChangesAsync();
                    return Ok(patientRequest);
                }
            }            
            return BadRequest();
        }

        [HttpDelete]
        [Route("id:guid")]
        public async Task<IActionResult> RemoveAppointment([FromRoute] Guid id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);
            if(patient != null)
            {
                patient.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return Ok(patient);
            }
            return NotFound();
            
        }
    }
}
