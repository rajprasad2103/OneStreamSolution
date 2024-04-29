using OneStreamBlazor.Models;
using System.Net.Http.Headers;
using System.Net.Http;

namespace OneStreamBlazor.Services
{
    public class DepartmentServices : IDepartmentService
    {
        private readonly HttpClient client = new HttpClient();

        public DepartmentServices(HttpClient client)
        {

            this.client = client;
        }
        public async Task<IEnumerable<Department>> GetDepartments(string jwtToken)
        {
            // Include token in request headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            return await client.GetFromJsonAsync<IEnumerable<Department>>("api/departments");
        
        }      

    }
}
