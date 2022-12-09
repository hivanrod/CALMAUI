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
    public class TipoRepeticionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoRepeticionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoRepeticiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoRepeticion>>> GetTipoRepeticion()
        {
            return await _context.TipoRepeticion.ToListAsync();
        }

        // GET: api/TipoRepeticiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoRepeticion>> GetTipoRepeticion(int id)
        {
            var tipoRepeticion = await _context.TipoRepeticion.FindAsync(id);

            if (tipoRepeticion == null)
            {
                return NotFound();
            }

            return tipoRepeticion;
        }

        // PUT: api/TipoRepeticiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoRepeticion(int id, TipoRepeticion tipoRepeticion)
        {
            if (id != tipoRepeticion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoRepeticion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoRepeticionExists(id))
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

        // POST: api/TipoRepeticiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoRepeticion>> PostTipoRepeticion(TipoRepeticion tipoRepeticion)
        {
            _context.TipoRepeticion.Add(tipoRepeticion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoRepeticion", new { id = tipoRepeticion.Id }, tipoRepeticion);
        }

        // DELETE: api/TipoRepeticiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoRepeticion(int id)
        {
            var tipoRepeticion = await _context.TipoRepeticion.FindAsync(id);
            if (tipoRepeticion == null)
            {
                return NotFound();
            }

            _context.TipoRepeticion.Remove(tipoRepeticion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoRepeticionExists(int id)
        {
            return _context.TipoRepeticion.Any(e => e.Id == id);
        }
    }
}
