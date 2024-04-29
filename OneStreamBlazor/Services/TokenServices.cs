using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace OneStreamBlazor.Services
{
    public class TokenServices : ITokenServices
    {
        [Inject]
        private IConfiguration Configuration { get; set; }

        private readonly HttpClient client = new HttpClient();
        public TokenServices(HttpClient client, IConfiguration Configuration) {
            this.client = client;
            this.Configuration = Configuration;
        }      

        public async Task<string> GetToken()
        {
            string xKey = Configuration["Security:SecretKey"];           
            try
            {
                // Make the POST request with JSON payload
                var response = await client.PostAsJsonAsync("Account/Token?xSecretKey="+ xKey,"");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Handle success
                    return await response.Content.ReadAsStringAsync();
                }               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;

        }
    }
}
