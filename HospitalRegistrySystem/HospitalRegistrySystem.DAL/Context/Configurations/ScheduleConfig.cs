using HospitalRegistrySystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalRegistrySystem.DAL.Context.Configurations {
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule> {
        public void Configure(EntityTypeBuilder<Schedule> builder) {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(s => s.Doctor)
                .WithMany(d => d.Schedules)
                .HasForeignKey(s => s.DoctorId);

            builder.Property(s => s.DateTime)
                .IsRequired();

            builder.Property(s => s.IsAviable)
                .IsRequired();
        }
    }
}
