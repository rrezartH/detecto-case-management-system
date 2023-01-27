using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Detecto.API.Case.Models;
using Detecto.API.Configurations;

namespace Detecto.API.Case.Controllers
{
    [Route("api/Case/[controller]")]
    [ApiController]
    public class DTaskController : ControllerBase
    {
        private readonly DetectoDbContext _context;

        public DTaskController(DetectoDbContext context)
        {
            _context = context;
        }

        // GET: api/DTask
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/DTask/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTask>> GetDTask(int id)
        {
            var dTask = await _context.Tasks.FindAsync(id);

            if (dTask == null)
            {
                return NotFound();
            }

            return dTask;
        }

        // PUT: api/DTask/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDTask(int id, DTask dTask)
        {
            if (id != dTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(dTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DTaskExists(id))
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

        // POST: api/DTask
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DTask>> PostDTask(DTask dTask)
        {
            _context.Tasks.Add(dTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDTask", new { id = dTask.Id }, dTask);
        }

        // DELETE: api/DTask/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDTask(int id)
        {
            var dTask = await _context.Tasks.FindAsync(id);
            if (dTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(dTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
