using OneStreamBlazor.Models;

namespace OneStreamBlazor.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployees(string jwtToken);
    }
}
