using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistrySystem.DAL.Context {
    public class HospitalRegistrySystemContextFactory : IDesignTimeDbContextFactory<HospitalRegistrySystemContext> {
        public HospitalRegistrySystemContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<HospitalRegistrySystemContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=HospitalRegistrySystemDB;Trusted_Connection=True;");

            return new HospitalRegistrySystemContext(optionsBuilder.Options);
        }
    }
}
