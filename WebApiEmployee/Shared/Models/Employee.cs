namespace WebApiEmployee.Shared.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
