using HospitalRegistrySystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalRegistrySystem.DAL.Context.Configurations {
    public class PatientCardConfig : IEntityTypeConfiguration<PatientCard> {
        public void Configure(EntityTypeBuilder<PatientCard> builder) {

            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(pc => pc.Patient)
                .WithOne(p => p.PatientCard)
                .HasForeignKey<PatientCard>(pc => pc.PatientId);
        }
    }
}
