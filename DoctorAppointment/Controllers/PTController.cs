using DoctorAppointment.Data;
using DoctorAppointment.Model;
using DoctorAppointment.Viewmodels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PTController : ControllerBase
    {
        private readonly DoctorAppointmentDbContext _context;
        public PTController(DoctorAppointmentDbContext context)
        {
            _context = context;
        }
        // GET: api/<PTController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PTController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PTController>
        [HttpPost]
        public void Post([FromBody] vclinicAdd item)
        {
            Clinic Obj = new Clinic();
            Obj.Name = item.name;

            _context.Clinics.Add(new Clinic()
            {
                Name = item.name
            });
            _context.SaveChanges();
        }

        // PUT api/<PTController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PTController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
