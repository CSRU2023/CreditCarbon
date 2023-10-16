using Microsoft.EntityFrameworkCore;
using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories;
using CreditCarbonAPI.Repositories.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<CarbonCreditContext>();
builder.Services.AddDbContext<CarbonCreditContext>(options =>
{
    options.UseSqlServer("Server=C1001226\\SQLEXPRESS;Database=CarbonCredit;User=sa; Password=1234; TrustServerCertificate=True;Encrypt=False;");
});

//AddScoped
builder.Services.AddScoped(typeof(ICarbonCreditEfRepository<>), typeof(CarbonCreditEfRepository<>));
builder.Services.AddScoped<IProjectCarbonMarketsRepository, ProjectCarbonMarketsRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
