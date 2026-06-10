using Microsoft.EntityFrameworkCore;
using WebApiEmployee.Features.Employees;
using WebApiEmployee.Shared.Database;

namespace WebApiEmployee.Features.Positions
{
    public class PositionService(AppDbContext _db)
    {
        // Async - Await da la posibilidad de ejecutar tareas a la vez o no espere a que una termine para que la otra empiece
        public async Task<IEnumerable<GetPosition>> GetAll()
        {
            var positions = await _db.Position.ToListAsync();

            return positions.Select(e => new GetPosition(
                PositionId: e.PositionId,
                Name: e.Name
                )).ToList();
        }
    }
}
