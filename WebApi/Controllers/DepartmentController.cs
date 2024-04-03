using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Responses;
using WebApi.Services;

namespace WebApi.Controllers;


[ApiController]
[Route("/api/Departments/")]
public class DepartmentController(IDepartmentService departmentService):ControllerBase
{
    private readonly IDepartmentService _departmentService = departmentService;

    [HttpGet]
    public Response<List<Department>> GetDepartments()
    {
        return _departmentService.GetDepartments();
    }

    [HttpGet("{depatmentId:int}")]
    public Response<Department> GetDepartmentById(int depatmentId)
    {
        return _departmentService.GetDepartmentById(depatmentId);
    }

    [HttpPost]
    public Response<string> AddDepartment(Department department)
    {
        return _departmentService.AddDepartment(department);
    }

    [HttpPut]
    public Response<string> UpdateDepartment(Department department)
    {
        return _departmentService.UpdateDepartment(department);
    }

    [HttpDelete("{depatmentId:int}")]
    public Response<bool> DeleteDepartment(int departmentId)
    {
        return _departmentService.DeleteDepartment(departmentId);
    }
}