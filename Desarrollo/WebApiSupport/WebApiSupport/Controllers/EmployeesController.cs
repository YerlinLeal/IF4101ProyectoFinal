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
            return await _context.Employees.Where(e => e.State==true).Select(e =>
            new
            {
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
                 e.Supervised,
                 e.EmployeeType,
                 e.Email
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
        [HttpPut]
        public async Task<IActionResult> PutEmployeeAsync(Employee em)
        {

            var employee = await _context.Employees.FindAsync(em.EmployeeId);
            employee.EmployeeName = em.EmployeeName;
            employee.FirstSurname = em.FirstSurname;
            employee.SecondSurname = em.SecondSurname;
            employee.Email = em.Email;
            employee.ModifyDate = DateTime.Now;

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Conflict(ex.HResult);

            }

            
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult PostEmployee(EmployeeDTO employee)
        {
            var outP = new SqlParameter
            {
                ParameterName = "LastId",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };
            var sql = "[dbo].[InsertEmployee] {0},{1},{2},{3},{4},{5},{6},{7},@LastId OUT";
            try
            {
                var result = _context.Database.ExecuteSqlRaw(sql, employee.EmployeeName, employee.FirstSurname, employee.SecondSurname, employee.Email, employee.Password,
                    employee.EmployeeType, employee.CreatedBy, employee.Supervised, outP);
                int out1Value = (int)outP.Value;
                List<int> services = employee.Services;

                for (int i = 0; i < services.Count; i++)
                {
                    _context.Employees.Find(out1Value).EmployeeServices.Add(new EmployeeService() { 
                        EmployeeId = out1Value,
                        ServiceId = services[i],
                        State = true,
                        CreatedBy = employee.CreatedBy
                    });
                }
                _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e) {
                return Conflict(e.Message);
            }
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
