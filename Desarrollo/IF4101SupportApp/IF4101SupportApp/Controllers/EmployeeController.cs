using IF4101SupportApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IF4101SupportApp.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;
        private List<Employee> employees;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPISupportBaseUrl");
            employees = new List<Employee>();
            employees.Add(new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "Maikel",
                FirstSurname = "Matamoros",
                SecondSurname = "Zuñiga",
                Email = "Maikel@Correo.com",
                Password = "12345",
                Supervised = 1,
                Services = new List<int>() { 1,2,3 }
            });
            employees.Add(new Employee()
            {
                EmployeeId = 2,
                EmployeeName = "Arturo",
                FirstSurname = "Campos",
                SecondSurname = "Bogantes",
                Email = "Bogantes@Correo.com",
                Password = "54321",
                Supervised = 1,
                Services = new List<int>() { 1, 3, 4 }
            });
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Employee employee)
        {
            ObjectResult result = null;
            using HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8,
                "application/json");
            using (var Response = await client.PostAsync(apiBaseUrl + "Employee", content))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = Ok(1);
                }
                else
                {
                    result = Conflict(Response.RequestMessage);
                }
            }
            return result;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllAsync()
        {
            //ObjectResult result = null;
            //using var client = new HttpClient();
            //using var Response = await client.GetAsync(apiBaseUrl + "Employee");
            //if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    result = Ok(JsonConvert.DeserializeObject<List<Employee>>
            //        (await Response.Content.ReadAsStringAsync()));
            //}
            //else
            //{
            //    result = Conflict(Response.RequestMessage);
            //}
            //return result;
            return (employees);
        }

        [HttpGet]
        public ActionResult<Employee> GetById(int id)
        {
            //ObjectResult result = null;
            //using var client = new HttpClient();
            //using var Response = await client.GetAsync(apiBaseUrl + "Employee");
            //if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    result = Ok(JsonConvert.DeserializeObject<List<Employee>>
            //        (await Response.Content.ReadAsStringAsync()));
            //}
            //else
            //{
            //    result = Conflict(Response.RequestMessage);
            //}
            //return result;
            Employee e = employees.FirstOrDefault(em => em.EmployeeId == id);
            return (e);
        }


    }
}
