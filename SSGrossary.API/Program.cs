using Microsoft.EntityFrameworkCore;
using SSGrossary.Domain.Interfaces;
using SSGrossary.Infranstructure;
using SSGrossary.Infranstructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
// Add services to the container.

builder.Services.AddScoped<ICountry,CountryRepository>();
builder.Services.AddScoped<IState,StateRepository>();
builder.Services.AddScoped<IDistrict, DistrictRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
