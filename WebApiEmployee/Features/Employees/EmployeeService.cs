using Microsoft.EntityFrameworkCore;
using WebApiEmployee.Shared.Database;
using WebApiEmployee.Shared.Models;

namespace WebApiEmployee.Features.Employees
{
    // toda la logica del CRUD
    public class EmployeeService(AppDbContext _db)
    {
        // Async - Await da la posibilidad de ejecutar tareas a la vez o no espere a que una termine para que la otra empiece
        public async Task<IEnumerable<GetEmployee>> GetAll()
        {
            var employees = await _db.Employee.Include(p => p.Position).ToListAsync();

            return employees.Select(e => new GetEmployee(
                EmployeeId: e.EmployeeId,
                FullName: e.FullName,
                Email: e.Email,
                BirthDate: e.BirthDate,
                PositionId: e.PositionId,
                Position: e.Position.Name
                )).ToList();
        }

        // Devuelve un empleado por Id
        public async Task<GetEmployee> GetById(int Id)
        {
            var e = await _db.Employee.Include(p => p.Position)
                .FirstAsync(e => e.EmployeeId == Id);

            return new GetEmployee(
                EmployeeId: e.EmployeeId,
                FullName: e.FullName,
                Email: e.Email,
                BirthDate: e.BirthDate,
                PositionId: e.PositionId,
                Position: e.Position.Name
                );
        }

        // Crea un empleado
        public async Task Add(CreateEmployee request)
        {
            var employee = new Employee()
            {
                FullName = request.FullName,
                Email = request.Email,
                BirthDate = request.BirthDate,
                PositionId = request.PositionId
            };

            await _db.Employee.AddAsync(employee);
            await _db.SaveChangesAsync();
        }

        // Editar un empleado
        public async Task Update(UpdateEmployee request)
        {
            var employeeFound = await _db.Employee.FirstAsync(e => e.EmployeeId == request.EmployeeId);

            employeeFound.FullName = request.FullName;
            employeeFound.Email = request.Email;
            employeeFound.BirthDate = request.BirthDate;
            employeeFound.PositionId = request.PositionId;

            await _db.SaveChangesAsync();
        }

        // Eliminar un empleado
        public async Task Delete(int Id)
        {
            var employeeFound = await _db.Employee.FirstAsync(e => e.EmployeeId == Id);

            _db.Employee.Remove(employeeFound);
            await _db.SaveChangesAsync();
        }
    }
}
