
using Business.Abstracts;
using Business.Concretes;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;
using Repositories.Concrete.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BaseDbContext>(op=> op.UseSqlServer(builder.Configuration.GetConnectionString("BaseDB"),
    sql => sql.MigrationsAssembly("Repositories")));

builder.Services.AddScoped<IApplicantService, ApplicantManager>(); //her http request i�in bir kez olu�turulur. AddScope ile lifecycle a eklenir.
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers(); // http isteklerini controllerlara y�nlendirir.

app.Run();