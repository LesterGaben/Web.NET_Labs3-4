using HospitalRegistrySystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalRegistrySystem.DAL.Context.Configurations {
    public class DoctorConfig : IEntityTypeConfiguration<Doctor> {
        public void Configure(EntityTypeBuilder<Doctor> builder) {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Speciality)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
