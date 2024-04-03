using System.Net;
using Dapper;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services;

public class CompanyService : ICompanyService
{
    private readonly DapperContext _context;

    public CompanyService(DapperContext context)
    {
        _context = context;
    }

    public Response<List<Company>> GetCompanies()
    {
        try
        {
            var sql = $"Select * from companies";
            var result = _context.Connection().Query<Company>(sql).ToList();
            return new Response<List<Company>>(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<List<Company>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<Company> GetCompanyById(int id)
    {
        try
        {
            var sql = $"Select * from companies where id = {@id}";
            var result = _context.Connection().QueryFirstOrDefault<Company>(sql);
            if (result != null) return new Response<Company>(result);
            return new Response<Company>(HttpStatusCode.BadRequest, "Student not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Company>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<string> AddCompany(Company company)
    {
        try
        {
        var sql = $"Insert into companies(companyname,description,location)" +
                  $"values ('{company.CompanyName}','{company.Description}','{company.Location}')";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<string>("Successfully created company");
        return new Response<string>(HttpStatusCode.BadRequest, "Could not create company");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }        
    }

    public Response<string> UpdateCompany(Company company)
    {
        try
        {
            var sql = $"Update companies " +
                      $"set companyname = '{company.CompanyName}',description = '{company.Description}',location = '{company.Location}' where id = {@company.Id}";
            var result = _context.Connection().Execute(sql);
            if (result > 0) return new Response<string>("Successfully updated company");
            return new Response<string>(HttpStatusCode.BadRequest, "Could not update company");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<bool> DeleteCompany(int id)
    {
        try
        {
        var sql = $"Delete from companies where id = {@id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.BadRequest, "Not found company", false);
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        }
}