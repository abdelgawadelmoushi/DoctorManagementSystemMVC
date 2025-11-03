
using DoctorManagementSystemMVC.Data;
using DoctorManagementSystemMVC.Models;
using DoctorManagementSystemMVC.Models.ViewModels;
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




        [HttpGet]
        public IActionResult DoctorsPage(int? spcId ,string DocName , int Page=1)
        {
            var doctors = _context.Doctors
                .Include(d => d.Specialization).AsQueryable()  ;
            var itemPerPage = 9;

            if (spcId != null && spcId !=0)
            {
                doctors = doctors.Where(e => e.SpecializationId == spcId);
            }

            if (DocName != null)
            {
                doctors = doctors.Where(e =>e.DocName.Contains(DocName));

            }
            var Count  = (int)Math.Ceiling((double)doctors.Count() / itemPerPage);
            doctors = doctors.Skip((Page - 1) * itemPerPage) .Take(itemPerPage);

            DocVM m = new DocVM
            {
                Doctors = doctors.ToList(),
                Patients = _context.Patients.ToList(),
                Appointments = _context.Appointments.ToList(),
                Specializations = _context.Specializations.ToList(),
                SpcId = spcId ?? 0,
                DocName = DocName,
                Count= Count - 1,
                CurrentPage=Page,
            };

            return View(m);
        }



        [HttpGet]
        public IActionResult Edit([FromRoute] int id, int doctorId)
        {
         
            var appointment = _context.appointments.FirstOrDefault(e => e.Id == id && e.DoctorId == doctorId);

            return View(appointment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Appointment appointment)
        {
            _context.appointments.Update(appointment);
            _context.SaveChanges();
            return RedirectToAction("AppointmentList", "Doctor");
        }


 

        [HttpGet]
        public IActionResult CompleteAppointment(int DoctorId)
        {
            // تحقق من وجود الطبيب
            var doctor = _context.Doctors.Find(DoctorId);
            if (doctor == null)
                return NotFound("Doctor not found.");

            // إنشاء مريض جديد تلقائيًا
            var patient = new Patient
            {
                Name = "Temporary Patient " + DateTime.Now.Ticks
            };
            _context.Patients.Add(patient);
            _context.SaveChanges();

            // إنشاء موعد جديد وربطه بالدكتور والمريض
            var appointment = new Appointment
            {
                DoctorId = doctor.Id,
            };

            ViewBag.DoctorId = doctor.Id;
            ViewBag.PatientId = patient.Id;

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompleteAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return View(appointment);

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("AppointmentList", "Doctor");
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
