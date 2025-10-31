using DoctorManagementSystemMVC.Data;
using DoctorManagementSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagementSystemMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentsController : Controller
    {
        ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReservationsManager()
        {
            var reservations = _context.appointments
                .Include(a => a.doctor)
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Time)
                .ToList();

            return View(reservations);
        }

     

        public IActionResult BookAppointment()
        {

            return RedirectToAction("DoctorsPage");
        }


        [HttpGet]
        public IActionResult AppointmentList()
        {
            var doctors = _context.Doctors
                .Include(d => d.Appointments)
                .ToList();

            return View(doctors);
        }


        public IActionResult SuccseededAppointement()
        {
            return RedirectToAction("AppointmentList");

        }
        [HttpGet]
        public IActionResult Edit(int id, int doctorId)
        {
            var appointment = _context.appointments.Find(id);

            if (appointment == null)
            {
                return NotFound("Appointment not found");
            }

            ViewBag.DoctorId = doctorId;
            ViewBag.Id = appointment.Id;

            return View(appointment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Appointment appointment)
        {
                       _context.appointments.Update(appointment);
             _context.SaveChanges();
            return RedirectToAction("AppointmentList");
        }


        //[HttpGet]
        //public IActionResult Delete(int id, int doctorId)
        //{
        //          return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(Appointment appointment)
        //{
        //    _context.appointments.Remove(appointment);
        //    _context.SaveChanges();
        //    return RedirectToAction("AppointmentList");
        //}


   
        public IActionResult Delete(int id)
        {
            var appointment  = _context.appointments.FirstOrDefault(x => x.Id == id);
            _context.appointments.Remove(appointment);
            _context.SaveChanges();
            return RedirectToAction("AppointmentList");
        }
    }
}
