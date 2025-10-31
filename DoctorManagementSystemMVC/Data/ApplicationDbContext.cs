using DoctorManagementSystemMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagementSystemMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Specialization> specializations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public object Appointment { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DoctorMangementSystemMVC;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
}
