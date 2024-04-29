using OneStreamBlazor.Models;

namespace OneStreamBlazor.Services
{
    public interface IDepartmentService
    {       
        Task<IEnumerable<Department>> GetDepartments(string jwtToken);
    }
}
