
namespace DoctorManagementSystemMVC.Models.ViewModels
{
    public class DocVM
    {
        public int DoctorId { get; set; }
        public List<Specialization> Specializations { get; set; } = new();
        public List<Doctor> Doctors { get; set; } = new();
        public List<Patient> Patients { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();

        public int SpcId { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public string DocName { get; set; } = "";


     
    }
}
