using System.Net;
using Dapper;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services;

public class DepartmentService:IDepartmentService
{
    private readonly DapperContext _context;

    public DepartmentService(DapperContext context)
    {
        _context = context;
    }

    public Response<List<Department>> GetDepartments()
    {
        try
        {
        var sql = $"Select * from departments";
        var result = _context.Connection().Query<Department>(sql).ToList();
        return new Response<List<Department>>(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<List<Department>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public Response<Department> GetDepartmentById(int id)
    {
        try
        {
            var sql = $"Select * from departments where id = {@id}";
            var result = _context.Connection().QueryFirstOrDefault<Department>(sql);
            if (result != null) return new Response<Department>(result);
            return new Response<Department>(HttpStatusCode.BadRequest, "Student not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Department>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<string> AddDepartment(Department department)
    {
        try
        {
        var sql = $"Insert into departments(department,description,employees,companyid) " +
                  $"values ('{department.DepartmentName}','{department.Description}',{department.Employees},{department.CompanyId})";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<string>("Successfully created department");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to create department");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public Response<string> UpdateDepartment(Department department)
    {
        try
        {
        var sql = $"Update departments " +
                  $"set department = '{department.DepartmentName}',description = '{department.Description}',employees = {department.Employees},companyid = {department.CompanyId} where id = {@department.Id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<string>("Successfully updated department");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to update department");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public Response<bool> DeleteDepartment(int id)
    {
        try
        {
        var sql = $"Delete from departments where id = {@id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.BadRequest,"Student not found",false);
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        }
}