using HospitalRegistrySystem.DAL.Context.Configurations;
using HospitalRegistrySystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace HospitalRegistrySystem.DAL.Context {
    public class HospitalRegistrySystemContext : DbContext {
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<MedicalConclusion> MedicalConclusions { get; set; }
        public virtual DbSet<PatientCard> PatientCards { get; set; }

        public HospitalRegistrySystemContext(DbContextOptions<HospitalRegistrySystemContext> options): base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientConfig).Assembly);
        }

    }
}
