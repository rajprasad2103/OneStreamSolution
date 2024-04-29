using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OneStream.Model;
using OneStreamBlazor.Models;
using OneStreamBlazor.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;

namespace OneStreamBlazor.Components.Pages
{
    public class EmployeesBase : ComponentBase
    {

        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }     
        public IEnumerable<Employee> EmployeeList { get; set; }
        [Inject]
        public IDepartmentService DepartmentServices { get; set; }
        [Inject]
        public ITokenServices JwtTokenServices { get; set; }
        public IEnumerable<Department> DepartmentList { get; set; }
        public List<EmployeesDispalyList> EmployeesDispaly { get; set; }

        private string JwtToken { get; set; }

        protected async override Task OnInitializedAsync()
        {          

            await callBackEndAPIs();
        }

        private async Task callBackEndAPIs()
        {
            try
            {
                GetJwtToken();
                // Start both API calls simultaneously
                var api2Task = callAPI2();
                var api3Task = callAPI3();
                var api2Response = await api2Task;
                var api3Response = await api3Task;

                CreateEmployeeDispayList();
            
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error calling APIs: {ex.Message}");
            }
        }

        private void CreateEmployeeDispayList()
        {
          var joined = from item1 in EmployeeList
                         join item2 in DepartmentList on item1.DepartId equals item2.DepartId
                         select new { Id = item1.Id, Name = item1.Name, Age = item1.Age, DepartId = item2.DepartId, DepartName = item2.DepartName };
                     
            string xEmployees = JsonConvert.SerializeObject(joined);
        
          EmployeesDispaly = JsonConvert.DeserializeObject<List<EmployeesDispalyList>>(xEmployees);
        }

        private async void GetJwtToken()
        {
            try
            {

                JwtToken = (await JwtTokenServices.GetToken());
               
            }
            catch (Exception ex)
            {
                // Handle exception
                System.Console.WriteLine($"Error calling API2: {ex.Message}");
                throw;
            }
        }

        private async Task<IEnumerable<Employee>> callAPI2()
        {
            try
            {
                // delay to mimic longer running operation
                await Task.Delay(3000); // 3 seconds delay

                // Make API call to API2

                EmployeeList = (await EmployeeServices.GetEmployees(JwtToken)).ToList();
                return EmployeeList;
            }
            catch (Exception ex)
            {
                // Handle exception
                System.Console.WriteLine($"Error calling API2: {ex.Message}");
                throw;
            }
        }

        private async Task<IEnumerable<Department>> callAPI3()
        {
            try
            {
                // delay to mimic longer running operation
                await Task.Delay(5000); // 5 seconds delay

                // Make API call to API3               
                DepartmentList = (await DepartmentServices.GetDepartments(JwtToken)).ToList();
                return DepartmentList;
            }
            catch (Exception ex)
            {
                // Handle exception
                System.Console.WriteLine($"Error calling API3: {ex.Message}");
                throw;
            }
        }   

       
    }

}

