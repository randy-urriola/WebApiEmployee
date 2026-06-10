namespace WebApiEmployee.Features.Employees
{
    public record CreateEmployee(
        string FullName,
        string Email,
        DateOnly BirthDate,
        int PositionId
    );

    public record UpdateEmployee(
        int EmployeeId,
        string FullName,
        string Email,
        DateOnly BirthDate,
        int PositionId
    );
}
