#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClasesMAUI.Models;
using ApiCalCore2.Data;

namespace ApiCalCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrioridadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Prioridades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prioridad>>> GetPrioridad()
        {
            return await _context.Prioridad.OrderBy(x => x.Orden).ToListAsync();
        }
        // GET: api/Prioridades/Cita
        [HttpGet("Cita")]
        public async Task<ActionResult<IEnumerable<Prioridad>>> GetPrioridadesCita()
        {
            return await _context.Prioridad.Where(x => x.Id > 9).ToListAsync();
        }

        // GET: api/Prioridades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prioridad>> GetPrioridad(int id)
        {
            var prioridad = await _context.Prioridad.FindAsync(id);

            if (prioridad == null)
            {
                return NotFound();
            }

            return prioridad;
        }

        // PUT: api/Prioridades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrioridad(int id, Prioridad prioridad)
        {
            if (id != prioridad.Id)
            {
                return BadRequest();
            }

            _context.Entry(prioridad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrioridadExists(id))
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

        // POST: api/Prioridades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prioridad>> PostPrioridad(Prioridad prioridad)
        {
            _context.Prioridad.Add(prioridad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrioridad", new { id = prioridad.Id }, prioridad);
        }

        // DELETE: api/Prioridades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrioridad(int id)
        {
            var prioridad = await _context.Prioridad.FindAsync(id);
            if (prioridad == null)
            {
                return NotFound();
            }

            _context.Prioridad.Remove(prioridad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrioridadExists(int id)
        {
            return _context.Prioridad.Any(e => e.Id == id);
        }
    }
}
