using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistrySystem.DAL.Context {
    public class HospitalRegistrySystemContextFactory : IDesignTimeDbContextFactory<HospitalRegistrySystemContext> {
        public HospitalRegistrySystemContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<HospitalRegistrySystemContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-N6QQ2A8;Database=HospitalRegistrySystemDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new HospitalRegistrySystemContext(optionsBuilder.Options);
        }
    }
}
