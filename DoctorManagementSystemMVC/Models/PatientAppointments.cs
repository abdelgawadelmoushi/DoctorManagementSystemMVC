namespace DoctorManagementSystemMVC.Models
{
    public class PatientAppointments
    {

        public string prescription { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }


    }
}
