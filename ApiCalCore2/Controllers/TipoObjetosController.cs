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
    public class TipoObjetosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoObjetosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoObjetos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoObjeto>>> GetTipoObjeto()
        {
            return await _context.TipoObjeto.ToListAsync();
        }

        // GET: api/TipoObjetos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoObjeto>> GetTipoObjeto(int id)
        {
            var tipoObjeto = await _context.TipoObjeto.FindAsync(id);

            if (tipoObjeto == null)
            {
                return NotFound();
            }

            return tipoObjeto;
        }

        // PUT: api/TipoObjetos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoObjeto(int id, TipoObjeto tipoObjeto)
        {
            if (id != tipoObjeto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoObjeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoObjetoExists(id))
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

        // POST: api/TipoObjetos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoObjeto>> PostTipoObjeto(TipoObjeto tipoObjeto)
        {
            _context.TipoObjeto.Add(tipoObjeto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoObjeto", new { id = tipoObjeto.Id }, tipoObjeto);
        }

        // DELETE: api/TipoObjetos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoObjeto(int id)
        {
            var tipoObjeto = await _context.TipoObjeto.FindAsync(id);
            if (tipoObjeto == null)
            {
                return NotFound();
            }

            _context.TipoObjeto.Remove(tipoObjeto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoObjetoExists(int id)
        {
            return _context.TipoObjeto.Any(e => e.Id == id);
        }
    }
}
