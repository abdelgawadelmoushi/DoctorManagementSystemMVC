namespace DoctorManagementSystemMVC.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;

     
        public int SpecializationId { get; set; }

        public Specialization? Specialization { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
