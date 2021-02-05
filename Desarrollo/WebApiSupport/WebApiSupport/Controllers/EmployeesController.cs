using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiSupport.Models;

namespace WebApiSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DB_A6E470_ProyectoIF4101Context _context;

        public EmployeesController()
        {
            _context = new DB_A6E470_ProyectoIF4101Context();
        }
        //https://localhost:44317/api/employees/GetSupporters
        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetSupporters()
        {
            ObjectResult result;
            try
            {
                result = Ok(from l in _context.Employees where l.EmployeeType == 2 select l);
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }
        //https://localhost:44317/api/employees/GetSupervisor
        [Route("[action]")]
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetSupervisor()
        {
            ObjectResult result;
            try
            {
                result = Ok(from l in _context.Employees where l.EmployeeType == 1 && l.State == true select l) ;
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }
        //https://localhost:44317/api/employees/GetSupportById
        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetSupportById(int id)
        {
            ObjectResult result;
            try
            {
                result = Ok(from l in _context.Employees where l.Supervised == id && l.State == true select new {l.EmployeeId,l.EmployeeName,l.FirstSurname });
            }
            catch (Exception e)
            {
                result = Conflict(e.Message);
            }
            return result;
        }
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployees()
        {
            return await _context.Employees.Select(e => 
            new { 
                e.EmployeeId,
                e.EmployeeName,
                e.FirstSurname,
                e.SecondSurname,
                e.Email
            }).ToListAsync<Object>();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<object> GetEmployee(int id)
        {
            var employee = _context.Employees.Where(e => e.EmployeeId == id).Select(e =>
             new
             {
                 e.EmployeeId,
                 e.EmployeeName,
                 e.FirstSurname,
                 e.SecondSurname,
                 e.Password,
                 e.EmployeeServices,
                 e.Supervised,
                 e.EmployeeType
             }).FirstOrDefault();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostEmployee(EmployeeDTO employee)
        {
            var outP = new SqlParameter
            {
                ParameterName = "LastId",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };
            var sql = "[dbo].[InsertEmployee] {0},{1},{2},{3},{4},{5},{6},{7},{8},@LastId OUT";
            var result = _context.Database.ExecuteSqlRaw(sql, employee.Dni, employee.EmployeeName, employee.FirstSurname, employee.SecondSurname, employee.Email, employee.Password, employee.EmployeeType, employee.CreatedBy, employee.Supervised, outP);

            int out1Value = (int)outP.Value;
            //_context.Employees.Add(employee);
            //await _context.SaveChangesAsync();
            return Ok(_context.Employees.FindAsync(out1Value));
            //return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }
        [Route("[action]")]
        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.State = false;
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        [Route("[action]")]
        [HttpGet()]
        public IActionResult Authentication(string email, string password)
        {
            ObjectResult result;
            var employee = _context.Employees
                           .FromSqlRaw("AuthenticateLogin {0}, {1}", email, password)
                           .AsEnumerable().SingleOrDefault();

            if (employee == null)
            {
                result = NotFound(employee);
            }
            else
            {
                result = Ok(employee);
            }

            return result;
        }


    }
}
