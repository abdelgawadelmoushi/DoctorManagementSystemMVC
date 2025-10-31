using DoctorManagementSystemMVC.Data;
using DoctorManagementSystemMVC.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DoctorManagementSystemMVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class DoctorController : Controller
    {
         ApplicationDbContext _context = new();



        //[HttpGet]
        //public IActionResult ReservationsManager()
        //{
        //    var reservations = _context.appointments
        //        .Include(a => a.doctor)
        //        .OrderBy(a => a.Date)
        //        .ThenBy(a => a.Time)
        //        .ToList();

        //    return View(reservations);
        //}

        public IActionResult DoctorsPage()
        {
             var doctors = _context.Doctors.Include(s => s.Specialization).ToList().ToList();
            return View(doctors);
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int id, int doctorId)
        {
            //var appointment = _context.appointments.Find(id);

            //if (appointment == null)
            //{
            //    return NotFound("Appointment not found");
            //}

            //ViewBag.DoctorId = doctorId;
            //ViewBag.Id = appointment.Id;
            var appointment = _context.appointments.FirstOrDefault(e=>e.Id==id && e.DoctorId==doctorId);

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


        //public IActionResult BookAppointment()
        //{

        //    return RedirectToAction("DoctorsPage");
        //}

        [HttpGet]
        public IActionResult CompleteAppointment(int DoctorId)
        {
            var appointment = new Appointment
            {
                DoctorId = DoctorId
            };
            ViewBag.DoctorId = DoctorId;

            return View(appointment);
        }

        [HttpPost]
        public IActionResult CompleteAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return View(appointment);

            _context.appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("AppointmentList", "Appointments", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult AppointmentList()
        {
            var doctors = _context.Doctors
                .Include(d => d.Appointments)
                .ToList();

            return View(doctors);
        }


    }
}
