using DoctorAppointment.Data;
using DoctorAppointment.Model;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorAppointmentDbContext _context;
        public DoctorController(DoctorAppointmentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
