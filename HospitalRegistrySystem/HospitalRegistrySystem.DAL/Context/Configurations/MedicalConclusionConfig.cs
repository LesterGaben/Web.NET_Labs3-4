using HospitalRegistrySystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalRegistrySystem.DAL.Context.Configurations {
    public class MedicalConclusionConfig : IEntityTypeConfiguration<MedicalConclusion> {
        public void Configure(EntityTypeBuilder<MedicalConclusion> builder) {
            builder.HasKey(mc => mc.Id);

            builder.Property(mc => mc.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(mc => mc.Doctor)
                .WithMany(d => d.MedicalConclusions)
                .HasForeignKey(mc => mc.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mc => mc.Patient)
                .WithMany(p => p.MedicalConclusions)
                .HasForeignKey(mc => mc.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mc => mc.PatientCard)
                .WithMany(pc => pc.MedicalConclusions)
                .HasForeignKey(mc => mc.PatientCardId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.Property(mc => mc.Content)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(mc => mc.DateTime)
                .IsRequired();
        }
    }
}
