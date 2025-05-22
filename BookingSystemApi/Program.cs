using BookingSystemApi.Data;
using BookingSystemApi.DTOs.Requests;
using BookingSystemApi.Repositories;
using BookingSystemApi.Repositories.Interfaces;
using BookingSystemApi.Services;
using BookingSystemApi.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<BookingDatabaseContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<AdminSeeder>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IValidator<UserRequestDto>, UserRequestDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<AdminSeeder>();
await seeder.SeedAdminAsync();