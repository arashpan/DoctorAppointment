using DoctorAppointment.Data;
using DoctorAppointment.Model;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.Controllers
{
    public class ClinicController : Controller
    {
        private readonly DoctorAppointmentDbContext _context;
        public ClinicController(DoctorAppointmentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var clinics = _context.Clinics.ToList();
            return View(clinics);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(string name)
        {
            _context.Clinics.Add(new Clinic()
            {
                Name = name
            });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var clinic = _context.Clinics.Find(id);
            _context.Clinics.Remove(clinic);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
