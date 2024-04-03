using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Responses;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/Employees/")]
public class EmployeeController(IEmployeeService employeeService):ControllerBase
{
    private readonly IEmployeeService _employeeService = employeeService;

    [HttpGet]
    public Response<List<Employee>> GetEmployees()
    {
        return _employeeService.GetEmployees();
    }

    [HttpGet("{employeeId:int}")]
    public Response<Employee> GetEmployeeById(int employeeId)
    {
        return _employeeService.GetEmployeeById(employeeId);
    }

    [HttpPost]
    public Response<string> AddEmployee(Employee employee)
    {
        return _employeeService.AddEmployee(employee);
    }

    [HttpPut]
    public Response<string> UpdateEmployee(Employee employee)
    {
        return _employeeService.UpdateEmployee(employee);
    }

    [HttpDelete("{employeeId:int}")]
    public Response<bool> DeleteEmployee(int employeeId)
    {
        return _employeeService.DeleteEmployee(employeeId);
    }
}