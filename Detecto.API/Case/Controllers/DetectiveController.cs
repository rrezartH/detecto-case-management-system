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
    [Route("api/[controller]")]
    [ApiController]
    public class DetectiveController : ControllerBase
    {
        private readonly DetectoDbContext _context;

        public DetectiveController(DetectoDbContext context)
        {
            _context = context;
        }

        // GET: api/Detective
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detective>>> GetDetectives()
        {
            return await _context.Detectives.ToListAsync();
        }

        // GET: api/Detective/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detective>> GetDetective(int id)
        {
            var detective = await _context.Detectives.FindAsync(id);

            if (detective == null)
            {
                return NotFound();
            }

            return detective;
        }

        // PUT: api/Detective/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetective(int id, Detective detective)
        {
            if (id != detective.Id)
            {
                return BadRequest();
            }

            _context.Entry(detective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetectiveExists(id))
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

        // POST: api/Detective
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Detective>> PostDetective(Detective detective)
        {
            _context.Detectives.Add(detective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetective", new { id = detective.Id }, detective);
        }

        // DELETE: api/Detective/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetective(int id)
        {
            var detective = await _context.Detectives.FindAsync(id);
            if (detective == null)
            {
                return NotFound();
            }

            _context.Detectives.Remove(detective);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetectiveExists(int id)
        {
            return _context.Detectives.Any(e => e.Id == id);
        }
    }
}
