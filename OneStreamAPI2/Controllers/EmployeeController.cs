using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStreamAPI2.Model;
using System;

namespace OneStreamAPI2.Controllers
{
  
    [ApiController]  
    public class EmployeeController : Controller
    {
       
        [HttpGet("api/Employees")]
        public IActionResult GetEmployees()
        {
            // Create an instance of the Person class
            List<Employee> xEmployee = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", Age = 30, DepartId=2 },
                new Employee { Id = 2, Name = "Jane Smith", Age = 35, DepartId=1 },
                new Employee { Id = 3, Name = "Michael Johnson", Age = 28, DepartId=3 }
            };

            // Return the person object as JSON
            return Json(xEmployee);
        }

    }
}
