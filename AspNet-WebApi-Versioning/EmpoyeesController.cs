using Asp.Versioning;
using AspNet_WebApi_Versioning.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_WebApi_Versioning;

[ApiController]
[ApiVersion(1, Deprecated = true)]
[ApiVersion(2)]
[Route("api/v{version:apiVersion}/[controller]")]
public class EmployeesController : ControllerBase
{
    private static List<Employee> EmployeesV1 = new()
    {
        new Employee { Id = 1, Name = "John Doe" },
        new Employee { Id = 2, Name = "Jane Doe" },
        new Employee { Id = 3, Name = "Sammy Doe" },
        new Employee { Id = 4, Name = "Sally Doe" },
        new Employee { Id = 5, Name = "Sue Doe" }
    };
    
    private static List<Employee> EmployeesV2 = new()
    {
        new Employee { Id = 1, Name = "John Doe" },
        new Employee { Id = 2, Name = "Jane Doe" },
        new Employee { Id = 3, Name = "Sammy Doe" },
    };
    
    [HttpGet]
    [MapToApiVersion(1)]
    public IActionResult GetEmployeesV1()
    {
        return Ok(EmployeesV1);
    }
    
    [HttpGet]
    [MapToApiVersion(2)]
    public IActionResult GetEmployeesV2()
    {
        return Ok(EmployeesV2);
    }
}