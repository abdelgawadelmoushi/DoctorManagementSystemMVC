using DoctorManagementSystemMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorManagementSystemMVC.Data.EntityConfiguration
{
    public class PatientDoctorEntityTypeConfiguration : IEntityTypeConfiguration<PatientDoctor>
    {
        public void Configure(EntityTypeBuilder<PatientDoctor> builder)
        {
            // المفتاح المركب
            builder.HasKey(e => new { e.PatientId, e.DoctorId });

            // علاقة مع Patient
            builder.HasOne(pd => pd.Patient)
                   .WithMany(p => p.PatientDoctors)
                   .HasForeignKey(pd => pd.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);

            // علاقة مع Doctor
            builder.HasOne(pd => pd.Doctor)
                .WithMany(d => d.PatientDoctors)
                .HasForeignKey(pd => pd.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
