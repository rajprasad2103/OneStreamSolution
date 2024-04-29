using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStreamAPI3.Models;

namespace OneStreamAPI3.Controllers
{
   
    [ApiController]
    public class DepartmentController : Controller
    {

        [HttpGet("api/Departments")]
        public IActionResult GetDepartments()
        {
            // Create an instance of the Departmen class
            List<Department> xDepartment = new List<Department>
            {
                new Department { DepartId = 1, DepartName = "Engineering" },
                new Department { DepartId = 2, DepartName = "Marketing" },
                new Department { DepartId = 3, DepartName = "Finance" }
            };

            // Return the Departmen object as JSON
            return Json(xDepartment);
        }
    }
}
