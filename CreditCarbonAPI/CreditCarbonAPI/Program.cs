using Microsoft.EntityFrameworkCore;
using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories;
using CreditCarbonAPI.Repositories.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5173",
            "http://localhost:5173")
                   .WithExposedHeaders("x-custom-header");
        });
});

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//builder.Services.AddDbContext<CarbonCreditContext>();
builder.Services.AddDbContext<CarbonCreditContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-K7IEBE5\\SQLEXPRESS;Database=CarbonCredit; Trusted_Connection=True;TrustServerCertificate=True;");
    // options.UseSqlServer("Server=C1001226\\SQLEXPRESS;Database=CarbonCredit;User=sa; Password=1234; TrustServerCertificate=True;Encrypt=False;");
    // options.UseSqlServer("Server=MSI\\MSSQLSERVER2;Database=CarbonCredit;Trusted_Connection=True;TrustServerCertificate=True;"); //Tam
});

//AddScoped
builder.Services.AddScoped(typeof(ICarbonCreditEfRepository<>), typeof(CarbonCreditEfRepository<>));
builder.Services.AddScoped<IProjectCarbonMarketsRepository, ProjectCarbonMarketsRepository>();
builder.Services.AddScoped<IProjectCarbonRepository, ProjectCarbonRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.UseCors("AllowCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
