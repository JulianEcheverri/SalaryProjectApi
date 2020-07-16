using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SalaryProject.DataAccess.EmployeeClient
{
    public class EmployeeClient : IEmployeeClient
    {
        private const string BaseUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";

        // Usamos inyeccion de dependencias con HttpClient para realizar la solicitud
        private readonly HttpClient _client;

        public EmployeeClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<T>> GetEmployees<T>()
        {
            using (var httpResponse = await _client.GetAsync(BaseUrl))
            {
                if (!httpResponse.IsSuccessStatusCode) throw new Exception(httpResponse.ReasonPhrase);
                string content = await httpResponse.Content.ReadAsStringAsync();
                List<T> employees = JsonConvert.DeserializeObject<List<T>>(content);
                return employees;
            }
        }
    }
}