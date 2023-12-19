using HospitalRegistrySystem.DAL.Context;
using HospitalRegistrySystem.DAL.Repositories.Inerfaces;
using HospitalRegistrySystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using HospitalRegistrySystem.BLL.Services;
using HospitalRegistrySystem.BLL.Services.Interfaces;
using HospitalRegistrySystem.DAL.Entities;
using HospitalRegistrySystem.BLL.DTOs;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddDbContext<HospitalRegistrySystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalRegistrySystemDb")));

builder.Services.AddScoped<IGenericService<Patient, PatientDTO>, PatientService<Patient, PatientDTO>>();

// Ðåºñòðàö³ÿ GenericRepository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(cfg => {
    cfg.CreateMap<Patient, PatientDTO>();
    cfg.CreateMap<PatientDTO, Patient>();
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
