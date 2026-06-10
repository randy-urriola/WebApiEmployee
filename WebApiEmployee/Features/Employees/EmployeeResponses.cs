namespace WebApiEmployee.Features.Employees
{
    public record GetEmployee(
        int EmployeeId,
        string FullName,
        string Email,
        DateOnly BirthDate,
        int PositionId,
        string Position
        );
}
