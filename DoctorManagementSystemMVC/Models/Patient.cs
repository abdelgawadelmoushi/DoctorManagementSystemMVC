namespace DoctorManagementSystemMVC.Models
{
    public class Patient
    {


        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;

        public List<PatientDoctor> PatientDoctors { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
        public string? Appointment { get; internal set; }
    }
}
