namespace WebApi.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
    public int Experience { get; set; }
    public int DepartmentId { get; set; }
}