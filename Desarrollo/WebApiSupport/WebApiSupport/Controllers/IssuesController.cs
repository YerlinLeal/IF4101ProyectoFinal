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
                            on l.EmployeeAssigned equals e.EmployeeId select new {l.ReportNumber,e.EmployeeName,e.FirstSurname,
                                                                                    l.Classification,l.Status,l.CreationDate,l.ReportTimestamp});
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }
        // GET: api/Issues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issues.ToListAsync();
        }

        // GET: api/Issues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        // PUT: api/Issues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}/{ReportNumber}/{EmployeeId}/{Status}")]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.ReportNumber)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

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
            catch (DbUpdateException)
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

            return CreatedAtAction("GetIssue", new { id = issue.ReportNumber }, issue);
        }

        // DELETE: api/Issues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> DeleteIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();

            return issue;
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.ReportNumber == id);
        }
    }
}
