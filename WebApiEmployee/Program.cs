using Microsoft.EntityFrameworkCore;
using WebApiEmployee.Features.Employees;
using WebApiEmployee.Features.Positions;
using WebApiEmployee.Shared.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Conexion a la base de datos
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Agregar los servicios
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<PositionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
