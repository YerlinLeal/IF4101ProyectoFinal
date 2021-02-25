﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApiSupport.Models;

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


        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetByReport(int id)
        {

            ObjectResult result = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using var client = new HttpClient(clientHandler);
            using var Response = await client.GetAsync(apiBaseUrl + "comment/comments/" + id);
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = Ok(JsonConvert.DeserializeObject<List<Issue>>
                    (await Response.Content.ReadAsStringAsync()));
            }
            else
            {
                result = Conflict(Response.RequestMessage);
            }
            return result;

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
        public void email(string email, string pass)
        {

            string EmialOrigin = "teleatlanticIF4101@gmail.com";
            string EmailDestiny = email;
            string password = pass;

            MailMessage oMailMessage = new MailMessage(EmialOrigin,EmailDestiny,"Hola, tu servicio:","<p></p>");
            oMailMessage.IsBodyHtml = true;
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmialOrigin, password);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();
            
        }

    }
}
