namespace WebApi.Models;

public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public string Description { get; set; }
    public int Employees { get; set; }
    public int CompanyId { get; set; }
}