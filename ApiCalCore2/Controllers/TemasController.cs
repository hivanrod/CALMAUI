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
    public class TemasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Temas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tema>>> GetTema()
        {
            return await _context.Tema.OrderBy(x => x.Prioridad.Orden).ThenBy(x => x.Descripcion).ToListAsync();
        }

        // GET: api/Temas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> GetTema(int id)
        {
            var tema = await _context.Tema.FindAsync(id);

            if (tema == null)
            {
                return NotFound();
            }

            return tema;
        }

        // GET: api/Temas/Prioridad/{id}
        [HttpGet("Prioridad/{id}")]
        public async Task<ActionResult<IEnumerable<Tema>>> GetTemaPrioridad(string id)
        {
            return await _context.Tema.Where(x => x.PrioridadId == Convert.ToInt64(id)).OrderBy(x => x.PrioridadId).ThenBy(x => x.Descripcion).ToListAsync();
        }

        //// GET: api/Temas/Cita/{id}
        //[HttpGet("Cita/{id}")]
        //public async Task<ActionResult<IEnumerable<Tema>>> GetTemaCita(string id)
        //{
        //    var citas = await _context.Cita.Where(x => x.TemaId == Convert.ToInt64(id)).ToListAsync();
        //    return await _context.Tema.Where(x => x.Id == (citas) .PrioridadId == Convert.ToInt64(id)).OrderBy(x => x.PrioridadId).ThenBy(x => x.Descripcion).ToListAsync();
        //}


        // PUT: api/Temas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTema(int id, Tema tema)
        {
            if (id != tema.Id)
            {
                return BadRequest();
            }
            //DateTime currentDateTime = DateTime.Now;
            //tema.FechaHora = currentDateTime;
            _context.Entry(tema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemaExists(id))
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

        // POST: api/Temas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tema>> PostTema(Tema tema)
        {
            DateTime currentDateTime = DateTime.Now;
            tema.FechaHora = currentDateTime;
            _context.Tema.Add(tema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTema", new { id = tema.Id }, tema);
        }

        // DELETE: api/Temas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTema(int id)
        {
            var tema = await _context.Tema.FindAsync(id);
            if (_context.Cita.Where(x => x.Id == tema.Id).FirstOrDefault() != null)
            {
                return Unauthorized(tema.Id);
            }
            if (_context.Tarea.Where(x => x.TemaId == tema.Id).FirstOrDefault() != null)
            {
                return Unauthorized(tema.Id);
            }
            if (tema == null)
            {
                return NotFound();
            }

            _context.Tema.Remove(tema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemaExists(int id)
        {
            return _context.Tema.Any(e => e.Id == id);
        }
    }
}
