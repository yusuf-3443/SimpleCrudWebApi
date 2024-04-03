using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Responses;
using WebApi.Services;

namespace WebApi.Controllers;


[ApiController]
[Route("/api/Companies/")]

public class CompanyController(ICompanyService companyService):ControllerBase
{
    private readonly ICompanyService _companyService = companyService;

    [HttpGet]
    public Response<List<Company>> GetCompanies()
    {
        return _companyService.GetCompanies();
    }

    [HttpGet("{companyId:int}")]
    public Response<Company> GetCompanyById(int companyId)
    {
        return _companyService.GetCompanyById(companyId);
    }

    [HttpPost]
    public Response<string> AddCompany(Company company)
    {
        return _companyService.AddCompany(company);
    }

    [HttpPut]
    public Response<string> UpdateCompany(Company company)
    {
        return _companyService.UpdateCompany(company);
    }

    [HttpDelete("{companyId:int}")]
    public Response<bool> DeleteCompany(int companyId)
    {
        return _companyService.DeleteCompany(companyId);
    }
}