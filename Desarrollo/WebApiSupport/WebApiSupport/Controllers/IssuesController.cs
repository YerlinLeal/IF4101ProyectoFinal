using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSupport.Models;
using WebApiSupport.Models.DTO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;

namespace WebApiSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly DB_A6E470_ProyectoIF4101Context _context;
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;
        public IssuesController(IConfiguration configuration)
        {
            _context = new DB_A6E470_ProyectoIF4101Context();
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPIClientBaseUrl");
        }
        //https://localhost:44317/api/issues/GetIssuesE
        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<Issue>> GetIssuesE()
        {
            ObjectResult result;
            try
            {
                result =Ok( from l in _context.Issues
                             where l.State == true
                             select new
                             {
                                 l.ReportNumber,
                                 l.EmployeeAssignedNavigation.EmployeeName,
                                 l.EmployeeAssignedNavigation.FirstSurname,
                                 l.Classification,
                                 l.Status,
                                 l.CreationDate,
                                 l.ReportTimestamp
                             });
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }
        // GET: api/Issues
        [Route("[action]/{ReportNumber}")]
        [HttpGet]
        public ActionResult<Issue> GetIssuesById(int ReportNumber)
        {
            ObjectResult result;
            try
            {
                result = Ok(from l in _context.Issues
                            where l.ReportNumber== ReportNumber && l.State==true
                            select new
                            {
                                l.ReportNumber,
                                l.EmployeeAssigned,
                                l.EmployeeAssignedNavigation.EmployeeName,
                                l.EmployeeAssignedNavigation.FirstSurname,
                                l.EmployeeAssignedNavigation.SecondSurname,
                                l.EmployeeAssignedNavigation.Supervised,
                                l.Classification,
                                l.Status,
                                l.CreationDate,
                                l.ReportTimestamp,
                                l.ResolutionComment
                            });
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<Issue> GetIssuesRById(int id)
        {
            ObjectResult result;
            try
            {
                result = Ok(from l in _context.Issues
                            join e in _context.Employees

                    on l.EmployeeAssigned equals e.EmployeeId
                            where e.EmployeeId == id && l.State == true && e.State==true
                            select new
                            {
                                l.ReportNumber,
                                e.EmployeeId,
                                e.EmployeeName,
                                e.FirstSurname,
                                e.SecondSurname,
                                e.Supervised,
                                l.Classification,
                                l.Status,
                                l.CreationDate,
                                l.ReportTimestamp,
                                l.ResolutionComment
                            });
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }


        // PUT: api/Issues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {

            email(issue);
            _context.Entry(issue).State = EntityState.Modified;
            _context.Entry(issue).Property(x => x.ReportTimestamp).IsModified = false;
            _context.Entry(issue).Property(x => x.Service).IsModified = false;
            _context.Entry(issue).Property(x => x.State).IsModified = false;
            _context.Entry(issue).Property(x => x.CreationDate).IsModified = false;
            _context.Entry(issue).Property(x => x.ModifyDate).IsModified = false;
            _context.Entry(issue).Property(x => x.CreatedBy).IsModified = false;
           

            try
            {
                await _context.SaveChangesAsync();
                await updateIssueStatusFromClient(issue);
                await updateIssueSupporterFromClient(issue);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Issues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Issue>> PostIssue(Issue issue)
        {
            
            issue.Classification = "M";
            _context.Issues.Add(issue);
            try
            {
                await _context.SaveChangesAsync();
                email(issue);
            }
            catch (DbUpdateException ex)
            {
                if (IssueExists(issue.ReportNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return issue;
        }
        [Route("[action]")]
        // DELETE: api/Issues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> DeleteIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            issue.State = false;
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return issue;
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.ReportNumber == id);
        }


      




        //https://localhost:44317/api/issues/GetAll
        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<Issue>> GetAll()
        {
            ObjectResult result;
            try
            {
                result = Ok(from l in _context.Issues
                            join e in _context.Employees
                            on l.EmployeeAssigned equals e.EmployeeId
                            into r from s in r.DefaultIfEmpty()
                            where l.State==true
                            select new
                            {
                                l.ReportNumber,
                                s.EmployeeName,
                                s.FirstSurname,
                                l.Classification,
                                l.Status,
                                l.CreationDate,
                                l.ReportTimestamp
                            });
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }


        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetByReport(int id)
        {

            ObjectResult result = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var client = new HttpClient(clientHandler);
            using var Response = await client.GetAsync(apiBaseUrl + "issue/issues/" + id);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = Ok(JsonConvert.DeserializeObject<List<ClientDTO>>
                    (await Response.Content.ReadAsStringAsync()));
            }

            else
            {
                result = Conflict(Response.RequestMessage);
            }
            return result;
        }
        //https://localhost:44317/api/issues/GetReportDataFromClient/reportNumber
        [Route("[action]/{reportNumber}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetReportDataFromClient(int reportNumber)
        {
            ObjectResult result = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var client = new HttpClient(clientHandler);
            using var Response = await client.GetAsync(apiBaseUrl + "report/getReportData/" + reportNumber);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = Ok(JsonConvert.DeserializeObject<ClientDTO>
                    (await Response.Content.ReadAsStringAsync()));
            }
            else
            {
                result = Conflict(Response.RequestMessage);
            }
            return result;

        }

        public async Task<IActionResult> updateIssueStatusFromClient(Issue issue)
        {
            ObjectResult result = null;
            using HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(issue.Status), Encoding.UTF8,
                "application/json");
            using (var Response = await client.PutAsync(apiBaseUrl + "issue/updateStatus/" + issue.ReportNumber, content))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        
        public async Task<IActionResult> updateIssueSupporterFromClient(Issue issue)
        {
            ObjectResult result = null;
            using HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(issue.EmployeeAssigned), Encoding.UTF8,
                "application/json");
            using (var Response = await client.PutAsync(apiBaseUrl + "issue/updateSupporter/" + issue.ReportNumber, content))
            {
                if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public void email(Issue issue)
        {
            ClientDTO clientDTO = new ClientDTO();
            
            
            clientDTO = GetByClient(issue.ReportNumber).Result;
            string EmailOrigin = "teleatlanticIF4101@gmail.com";
            string EmailDestiny = clientDTO.EmailClient;
            string password = "If4101!@";
            MailMessage oMailMessage=new MailMessage();


            if (clientDTO.ReportNumber == issue.ReportNumber)
            {
                oMailMessage.From = new MailAddress(EmailOrigin);
                oMailMessage.To.Add(EmailDestiny);
                oMailMessage.IsBodyHtml = true;
                if (issue.Status == "I")
                {
                    oMailMessage.Subject="Report Sent";
                    oMailMessage.Body = "Hi"+"\n"+clientDTO.NameClient+ "Your report is: Entered"  + "," + " " + "Number report:" + " " + clientDTO.ReportNumber;
                }
                else
                if (issue.Status == "A")
                {
                    oMailMessage.Subject = "Report Sent";
                    oMailMessage.Body = "Hi" + "\n" + clientDTO.NameClient + "Your report is: Assigned" + " " + "," + " "+ "Number report:" + " " + clientDTO.ReportNumber;
                }
                else
                if (issue.Status == "P")
                {
                    oMailMessage.Subject = "Report Sent";
                    oMailMessage.Body = "Hi," + "\n" + clientDTO.NameClient + "Your report is: In progress" + " " + "," + " " + "Number report:" + " " + clientDTO.ReportNumber;
                }
                else
                if (issue.Status == "R")
                {
                    oMailMessage.Subject = "Report Sent";
                    oMailMessage.Body = "Hi," + "\n" + clientDTO.NameClient + "Your report is: Resolved" + " " + "," + " " + "Number report:" + " " + clientDTO.ReportNumber;
                }
            }

            
            
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigin, password);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();
            
        }
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ClientDTO> GetByClient(int id)
        {

            ClientDTO result = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var client = new HttpClient(clientHandler);
            using var Response = await client.GetAsync(apiBaseUrl + "report/getReportData/" + id);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = (JsonConvert.DeserializeObject<ClientDTO>
                    (await Response.Content.ReadAsStringAsync()));
            }
            else
            {
                result = null;
            }
            return result;

        }

    }
}
