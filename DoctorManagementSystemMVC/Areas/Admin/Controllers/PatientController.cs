using DoctorManagementSystemMVC.Data;
using DoctorManagementSystemMVC.Models;
using DoctorManagementSystemMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DoctorManagementSystemMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
         ApplicationDbContext _context = new();

        public List<Appointment> Appointments { get; private set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PatientPage()
        {
            var patients = _context.Patients.AsNoTracking().AsQueryable()
                .Include(p => p.Appointments)
                .Include(p => p.PatientDoctors)
                .ToList();
            DocVM m = new DocVM
            {
                Patients = patients,
                Appointments = Appointments
            };
                
            return View(m);
        }


        [HttpGet]
        public IActionResult PatientAppointments()
        {
            var patients = _context.Patients.Include(p => p.Appointments)
                    .ThenInclude(a => a.Doctor).ToList();
             

            var appointments = _context.appointments
        .Include(a => a.Patient)
        .ToList();
            var doctors  = _context.Doctors.ToList();

            DocVM m = new DocVM() { Appointments =appointments, 
                Patients= patients.ToList() 
            , Doctors= doctors
            };

            if (patients == null)
            {
                return NotFound("Appointment not found");
            }
            return View(m);
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
         return View();
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient , IFormFile Img)
        {
            if (Img is not null && Img.Length >0)
            {
                var fileName = Guid.NewGuid().ToString()+Path.GetExtension(Img.FileName);
                var filePath =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\PatientImages", fileName) ;
            
                
                //Input OutPut In system to save the image to wwwroot
                using (var stream = System.IO.File.Create(filePath))
                {
                    Img.CopyTo(stream);
                }

                patient.Img=fileName;

           }
            if (!ModelState.IsValid)

                _context.Patients.Add(patient);
            _context.SaveChanges();

            return RedirectToAction("PatientPage", "Patient", new { area = "Admin" });


        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patients = _context.appointments.Find(id);

            if (patients == null)
            {
                return NotFound("Appointment not found");
            }

          
            return View(patients);
        }

        public IActionResult Delete(int id)
        {
            var patient = _context.Patients.FirstOrDefault(x => x.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return RedirectToAction("PatientPage");
        }
    }
}
