using Microsoft.EntityFrameworkCore;
using HospitalRegistrySystem.DAL.Context;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;
using HospitalRegistrySystem.DAL.Repositories;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.BLL.Services;
using System.Reflection;
using HospitalRegistrySystem.BLL.MappingProfiles;

public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<HospitalRegistrySystemContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("HospitalRegistrySystemDb")));

        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IMedicalConclusionService, MedicalConclusionService>();
        services.AddScoped<IPatientCardService, PatientCardService>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddAutoMapper(Assembly.GetAssembly(typeof(PatientProfile)));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }
}
