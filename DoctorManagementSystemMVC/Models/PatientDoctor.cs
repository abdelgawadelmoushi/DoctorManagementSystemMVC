namespace DoctorManagementSystemMVC.Models
{
    public class PatientDoctor
    {
        public int Id { get; set; } // يفضل تضيف مفتاح أساسي

        public string Prescription { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public string Diagonse { get; set; } = string.Empty;
        public string Medicine { get; set; } = string.Empty;

       
        public int? AppointmentId { get; set; }      
        public Appointment? Appointment { get; set; } 

       
    }
}
