using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSupport.Models;

namespace WebApiSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly DB_A6E470_ProyectoIF4101Context _context;

        public IssuesController()
        {
            _context = new DB_A6E470_ProyectoIF4101Context();
        }
        //https://localhost:44317/api/issues/GetIssuesE
        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<Issue>> GetIssuesE()
        {
            ObjectResult result;
            try
            {
                result = Ok(from l in _context.Issues join e in _context.Employees 
                            on l.EmployeeAssigned equals e.EmployeeId where l.State==true && e.State== true select new {l.ReportNumber,e.EmployeeName,e.FirstSurname,
                                                                                    l.Classification,l.Status,l.CreationDate,l.ReportTimestamp});
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
                            join e in _context.Employees

                    on l.EmployeeAssigned equals e.EmployeeId
                    where l.ReportNumber== ReportNumber && l.State==true
                            select new
                            {
                                l.ReportNumber,
                                l.EmployeeAssigned,
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


    }
}
