using System.Net;
using Dapper;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DapperContext _context;

    public EmployeeService(DapperContext context)
    {
        _context = context;
    }

    public Response<List<Employee>> GetEmployees()
    {
        try
        {

        var sql = $"Select * from employees";
        var result = _context.Connection().Query<Employee>(sql).ToList();
        return new Response<List<Employee>>(result);
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<List<Employee>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public Response<Employee> GetEmployeeById(int id)
    {
        try
        {

        var sql = $"Select * from employees where id = {@id}";
        var result = _context.Connection().QueryFirstOrDefault<Employee>(sql);
        if (result != null) return new Response<Employee>(result);
        return new Response<Employee>(HttpStatusCode.BadRequest, "Department not found");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Employee>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public Response<string> AddEmployee(Employee employee)
    {
        try
        {

        var sql = $"Insert into employees(fullname,age,phone,email,salary,experience,departmentid)" +
                  $"values ('{employee.FullName}',{employee.Age},'{employee.Phone}','{employee.Email}',{employee.Salary},{employee.Experience},{employee.DepartmentId})";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<string>("Employee successfully added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add employee");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public Response<string> UpdateEmployee(Employee employee)
    {
        try
        {

        var sql = $"Update employees " +
                  $"set fullname = '{employee.FullName}',age = {employee.Age},phone = '{employee.Phone}',email = '{employee.Email}',salary = {employee.Salary},experience = {employee.Experience},departmentid = {employee.DepartmentId} where id = {@employee.Id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<string>("Employee successfully updated");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to update employee");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public Response<bool> DeleteEmployee(int id)
    {
        try
        {

        var sql = $"Delete from employees where id = {@id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.BadRequest, "Not found employee", false);
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        }
}