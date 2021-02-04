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
            issues.Add(new Issue()
            {
                ReportNumber = 1234,
                UserName = "Yerlin",
                UserFirstSurname = "Leal",
                UserSecondSurname = "Achí",
                Email = "yerlin.leal@ucr.ac.cr",
                Phone = 84206753,
                Address = "Urb. Manuel de Jesús",
                SecondContact = "Silvia Achí",
                ContactEmail = "siaczu@gmail.com",
                ContactPhone = 89654592,
                Classification = 'M',
                IdSupportAssigned = 1,
                Status = 'I',
                Comments = "Sin comentarios",
                Notes = new List<Note>() { new Note(1, "Se cae la conexión")},
                CreationDate = new DateTime(2020,12,28,10,34,22),
                ModifyDate = new DateTime(2020, 12, 28, 10, 34, 22),
                CreatedBy = 1,
                ModifiedBy = 1,
                ReportTimestamp = new DateTime(2020, 12, 28, 10, 34, 22)
            });
            issues.Add(new Issue()
            {
                ReportNumber = 1235,
                UserName = "Maikel",
                UserFirstSurname = "Matamoros",
                UserSecondSurname = "Cordero",
                Email = "maikel.matamoros@ucr.ac.cr",
                Phone = 88888888,
                Address = "La cruzada, antes",
                SecondContact = "Mamá de Maikel",
                ContactEmail = "mama@gmail.com",
                ContactPhone = 88888888,
                Classification = 'A',
                IdSupportAssigned = 2,
                Status = 'A',
                Comments = "Sin comentarios",
                Notes = new List<Note>() { new Note(1, "Se cae la conexión") },
                CreationDate = new DateTime(2020, 12, 28, 10, 34, 22),
                ModifyDate = new DateTime(2020, 12, 28, 10, 34, 22),
                CreatedBy = 1,
                ModifiedBy = 1,
                ReportTimestamp = new DateTime(2020, 12, 28, 10, 34, 22)
            });
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
        public async Task<IActionResult> Get(int reportNumber)
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
