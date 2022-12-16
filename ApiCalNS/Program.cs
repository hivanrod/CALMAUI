global using ClasesMAUI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ApiCalNS;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    //.AddJsonOptions();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//IServiceCollection serviceCollection = builder.Services.AddSqlServer.AddDbContext<ApiCalNSDbContext>(option => option.UseSqlServer(SqlServerDbContextOptionsExtensions..UseSqlServer("DefaultConnection")));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
