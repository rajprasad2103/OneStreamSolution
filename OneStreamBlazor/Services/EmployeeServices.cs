using OneStreamBlazor.Models;
using System.Net.Http.Headers;

namespace OneStreamBlazor.Services
{
    public class EmployeeServices : IEmployeeServices
    {     
        private readonly HttpClient client = new HttpClient();
        public EmployeeServices(HttpClient client) { 
        
            this.client = client;
        }   

        public async Task<IEnumerable<Employee>> GetEmployees(string jwtToken)
        {
            // Include token in request headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            return await client.GetFromJsonAsync<IEnumerable<Employee>>("api/employees");
        }
  
    }
}
