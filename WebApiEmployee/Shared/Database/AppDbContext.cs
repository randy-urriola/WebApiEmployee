using Microsoft.EntityFrameworkCore;
using WebApiEmployee.Shared.Models;

namespace WebApiEmployee.Shared.Database
{
    // Clase que funciona, crea o mapea las tablas BD
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Position { get; set; }
    }
}
