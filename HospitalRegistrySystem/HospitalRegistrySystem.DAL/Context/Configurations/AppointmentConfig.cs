using HospitalRegistrySystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalRegistrySystem.DAL.Context.Configurations {
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment> {
        public void Configure(EntityTypeBuilder<Appointment> builder) {

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .IsRequired(false);

            builder.Property(a => a.DateTime)
                .IsRequired();
        }
    }
}
