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
    public class RepeticionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RepeticionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Repeticiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repeticion>>> GetRepeticion()
        {
            return await _context.Repeticion.ToListAsync();
        }

        // GET: api/Repeticiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repeticion>> GetRepeticion(int id)
        {
            var repeticion = await _context.Repeticion.FindAsync(id);

            if (repeticion == null)
            {
                return NotFound();
            }

            return repeticion;
        }

        // GET: api/Repeticiones/Tema/5
        [HttpGet("tema/{id}")]
        public async Task<ActionResult<IEnumerable<Repeticion>>> GetRepeticionesTema(int id)
        {
            var repeticion = await _context.Repeticion.Where(x => x.TemaId == id).ToListAsync();

            if (repeticion == null)
            {
                return NotFound();
            }

            return repeticion;
        }
        // GET: api/Repeticiones/Cita/5
        [HttpGet("cita/{id}")]
        public async Task<ActionResult<IEnumerable<Repeticion>>> GetRepeticionesCita(int id)
        {
            var repeticion = await _context.Repeticion.Where(x => x.CitaId == id).ToListAsync();

            if (repeticion == null)
            {
                return NotFound();
            }

            return repeticion;
        }
        // GET: api/Repeticiones/Tarea/5
        [HttpGet("tarea/{id}")]
        public async Task<ActionResult<IEnumerable<Repeticion>>> GetRepeticionesTarea(int id)
        {
            var repeticion = await _context.Repeticion.Where(x => x.TareaId == id).ToListAsync();

            if (repeticion == null)
            {
                return NotFound();
            }

            return repeticion;
        }


        // PUT: api/Repeticiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepeticion(int id, Repeticion repeticion)
        {
            if (id != repeticion.Id)
            {
                return BadRequest();
            }
            switch (repeticion.IdTipoObjeto)
            {
                case 1:
                    repeticion.TipoObjetoId = repeticion.IdTipoObjeto;
                    repeticion.CitaId = repeticion.IdObjeto;
                    break;
                case 2:
                    repeticion.TipoObjetoId = repeticion.IdTipoObjeto;
                    repeticion.TareaId = repeticion.IdObjeto;
                    break;
            }
            _context.Entry(repeticion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepeticionExists(id))
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

        // POST: api/Repeticiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repeticion>> PostRepeticion(Repeticion repeticion)
        {
            switch (repeticion.IdTipoObjeto)
            {
                case 1:
                    repeticion.TipoObjetoId = repeticion.IdTipoObjeto;
                    repeticion.CitaId = repeticion.IdObjeto;
                    break;
                case 2:
                    repeticion.TipoObjetoId = repeticion.IdTipoObjeto;
                    repeticion.TareaId = repeticion.IdObjeto;
                    break;
            }
            _context.Repeticion.Add(repeticion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepeticion", new { id = repeticion.Id }, repeticion);
        }

        // DELETE: api/Repeticiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepeticion(int id)
        {
            var repeticion = await _context.Repeticion.FindAsync(id);
            if (repeticion == null)
            {
                return NotFound();
            }

            _context.Repeticion.Remove(repeticion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepeticionExists(int id)
        {
            return _context.Repeticion.Any(e => e.Id == id);
        }
    }
}
