
using Business;
using Business.Abstracts;
using Business.Concretes;
using Core.Exceptions.Extentions;
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
    app.ConfigureCustomExceptionMiddleware(); //exception lar bu þekilde sisteme entegre edilir.
}

if (app.Environment.IsProduction()) //canlý ortamda saçma hata foormatlarýný göstermez.
{
    app.ConfigureCustomExceptionMiddleware();
}

app.MapControllers(); // http isteklerini controllerlara yönlendirir.

app.Run();