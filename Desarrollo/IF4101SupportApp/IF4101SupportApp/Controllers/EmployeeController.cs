using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF4101SupportApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace IF4101SupportApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;

        public EmployeeController( IConfiguration configuration)
        {
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync( Employee employee)
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
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            using var client = new HttpClient();
            using var Response = await client.GetAsync(apiBaseUrl + "Employee");
            ObjectResult result;
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = Ok(JsonConvert.DeserializeObject<List<Employee>>
                    (await Response.Content.ReadAsStringAsync()));
            }
            else
            {
                result = Conflict(Response.RequestMessage);
            }
            return result;
        }
    }
}
