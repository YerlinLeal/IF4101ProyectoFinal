﻿using System;
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
    public class EmployeeServicesController : ControllerBase
    {
        private readonly DB_A6E470_ProyectoIF4101Context _context;

        public EmployeeServicesController()
        {
            _context = new DB_A6E470_ProyectoIF4101Context();
        }

        // GET: api/EmployeeServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeService>>> GetEmployeeServices()
        {
            return await _context.EmployeeServices.ToListAsync();
        }

        // GET: api/EmployeeServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeService>> GetEmployeeService(int id)
        {
            var employeeService = await _context.EmployeeServices.FindAsync(id);

            if (employeeService == null)
            {
                return NotFound();
            }

            return employeeService;
        }

        // PUT: api/EmployeeServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeService(int id, EmployeeService employeeService)
        {
            if (id != employeeService.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeServiceExists(id))
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

        // POST: api/EmployeeServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeService>> PostEmployeeService(EmployeeService employeeService)
        {
            _context.EmployeeServices.Add(employeeService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeServiceExists(employeeService.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeService", new { id = employeeService.EmployeeId }, employeeService);
        }

        // DELETE: api/EmployeeServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeService>> DeleteEmployeeService(int id)
        {
            var employeeService = await _context.EmployeeServices.FindAsync(id);
            if (employeeService == null)
            {
                return NotFound();
            }

            employeeService.State = false;
            _context.Entry(employeeService).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return employeeService;
        }

        private bool EmployeeServiceExists(int id)
        {
            return _context.EmployeeServices.Any(e => e.EmployeeId == id);
        }
    }
}
