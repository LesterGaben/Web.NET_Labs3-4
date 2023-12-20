using HospitalRegistrySystem.DAL.Context;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;
using HospitalRegistrySystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using HospitalRegistrySystem.BLL.Services;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using System.Reflection;
using HospitalRegistrySystem.BLL.DTOs.Patient;
using HospitalRegistrySystem.BLL.DTOs.Doctor;
using HospitalRegistrySystem.BLL.DTOs.Appointment;
using HospitalRegistrySystem.BLL.DTOs.Schedule;
using HospitalRegistrySystem.BLL.DTOs.MedicalConclusion;
using HospitalRegistrySystem.BLL.DTOs.PatientCard;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







builder.Services.AddDbContext<HospitalRegistrySystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalRegistrySystemDb")));

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IMedicalConclusionService, MedicalConclusionService>();
builder.Services.AddScoped<IPatientCardService, PatientCardService>();

// Ðåºñòðàö³ÿ GenericRepository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<Patient, PatientDTO>().ForMember(dto => dto.PatientId, opt => opt.MapFrom(entity => entity.Id));
    cfg.CreateMap<PatientDTO, Patient>();
    cfg.CreateMap<CreateUpdatePatientDTO, Patient>();
}, Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<Doctor, DoctorDTO>().ForMember(dto => dto.DoctorId, opt => opt.MapFrom(entity => entity.Id));
    cfg.CreateMap<DoctorDTO, Doctor>();
    cfg.CreateMap<CreateUpdateDoctorDTO, Doctor>();
}, Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<Appointment, AppointmentDTO>().ForMember(dto => dto.AppointmentId, opt => opt.MapFrom(entity => entity.Id));
    cfg.CreateMap<AppointmentDTO, Appointment>();
    cfg.CreateMap<CreateUpdateAppointmentDTO, Appointment>();
}, Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<Schedule, ScheduleDTO>().ForMember(dto => dto.ScheduleId, opt => opt.MapFrom(entity => entity.Id));
    cfg.CreateMap<ScheduleDTO, Schedule>();
    cfg.CreateMap<CreateScheduleDTO, Schedule>();
    cfg.CreateMap<UpdateScheduleDTO, Schedule>();
}, Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<MedicalConclusion, MedicalConclusionDTO>().ForMember(dto => dto.MedicalConclusionId, opt => opt.MapFrom(entity => entity.Id));
    cfg.CreateMap<MedicalConclusionDTO, MedicalConclusion>();
    cfg.CreateMap<CreateMedicalConclusionDTO, MedicalConclusion>();
    cfg.CreateMap<UpdateMedicalConclusionDTO, MedicalConclusion>();
}, Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<PatientCard, PatientCardDTO>()
    .ForMember(dto => dto.PatientCardId, opt => opt.MapFrom(entity => entity.Id))
    .ForMember(dest => dest.MedicalConclusions, opt => opt.MapFrom(src => src.MedicalConclusions));
    cfg.CreateMap<PatientCardDTO, PatientCard>();
    cfg.CreateMap<CreatePatientCardDTO, PatientCard>();
}, Assembly.GetExecutingAssembly());






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
