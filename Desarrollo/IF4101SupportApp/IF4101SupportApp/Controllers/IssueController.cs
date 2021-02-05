using IF4101SupportApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IF4101SupportApp.Controllers
{
    public class IssueController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;
        private List<Issue> issues;

        public IActionResult Index()
        {
            return View();
        }
        public IssueController(IConfiguration configuration)
        {
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPISupportBaseUrl");
            issues = new List<Issue>();

        }
        public async Task<IActionResult> GetAll()
        {
            ObjectResult objectResult;
            using (var client = new HttpClient())
            {
                using (var Response = await client.GetAsync("https://localhost:44317/api/issues/GetIssuesE"))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await Response.Content.ReadAsStringAsync();
                        objectResult = Ok(JsonConvert.DeserializeObject<List<Issue>>(apiResponse));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                        objectResult = Conflict(new List<Issue>());
                    }
                }
            }
            return objectResult;
        }
        public async Task<IActionResult> GetIssue(int reportNumber)
        {
            ObjectResult result;
            using (var client = new HttpClient())
            {
                using (var Response = await client.GetAsync("https://localhost:44317/api/Issues/" + reportNumber))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        try
                        {
                            result = Ok(JsonConvert.DeserializeObject<Issue>(await Response.Content.ReadAsStringAsync()));

                        }
                        catch (Exception e)
                        {
                            return null;
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                        result = Conflict(new Issue());
                    }
                }
            }
            return result;
        }
    
    
    }
}
