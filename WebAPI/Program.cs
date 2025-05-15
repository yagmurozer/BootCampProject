
using Business;
using Business.Abstracts;
using Business.Concretes;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;
using Repositories.Concrete.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBusinessServices();
builder.Services.AddRepositoriesServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers(); // http isteklerini controllerlara yönlendirir.

app.Run();