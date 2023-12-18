using HospitalRegistrySystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace HospitalRegistrySystem.DAL.Context.Configurations {
    public class PatientConfig : IEntityTypeConfiguration<Patient> {
        public void Configure(EntityTypeBuilder<Patient> builder) {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(p => p.PatientCard)
                .WithOne(pc => pc.Patient)
                .HasForeignKey<Patient>(p => p.PatientCardId);

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(100);

            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime));

            builder.Property(p => p.DateOfBirth)
                .IsRequired()
                .HasConversion(dateOnlyConverter);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
