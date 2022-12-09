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
    public class TareasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTarea()
        {
            return await _context.Tarea.OrderBy(x => x.Verificado).ThenBy(x => x.IdImportancia).ToListAsync();
        }
        // GET: api/Tareas/Activas
        [HttpGet("Activas")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasActivas()
        {
            return await _context.Tarea.Where(x => x.Verificado == false).OrderBy(x => x.Descripcion).ToListAsync();
        }

        // GET: api/Tareas/tema/5
        [HttpGet("tema/{id}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasTema(int id)
        {
            // var cita = await _context.Cita.FindAsync(id);
            var tareas = await _context.Tarea.Where(x => x.TemaId == id).OrderByDescending(y => y.FechaInicio).ToListAsync();

            if (tareas == null)
            {
                return NotFound();
            }

            return tareas;
        }


        // GET: api/Tareas/Historico/5
        [HttpGet("Historico/{id}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareaHistorico(string id)
        {
            return await _context.Tarea.Where(x => x.TemaId == Convert.ToInt32(id)).OrderByDescending(x => x.FechaInicio).ThenBy(x => x.IdImportancia).ToListAsync();
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var tarea = await _context.Tarea.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return tarea;
        }



        // GET: api/Tareas/Fecha/{fecha}
        [HttpGet("Fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasFecha(string fecha)
        {
            if (fecha == null)
            {
                throw new ArgumentNullException(nameof(fecha));
            }
            else
            {
                var fecha2 = Convert.ToDateTime(fecha.Replace("'", "")).Date;
                var fecha1 = fecha2.AddDays(-1);
                var fecha3 = fecha2.AddDays(1);
                var tareas2 = await _context.Tarea.Where(x => x.FechaInicio <= fecha2 && x.FechaFinaliza >= fecha2).OrderBy(x => x.Verificado).ThenBy(x => x.TemaId).ThenBy(x => x.FechaInicio).ToListAsync();
                var tareas = tareas2;
                //var cita = await _context.Cita.ToListAsync();

                if (tareas != null)
                {
                    return tareas;
                }
                return tareas;
            }
        }







        // PUT: api/Tareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(id))
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

        // POST: api/Tareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
        {
            tarea.FechaRegistro = DateTime.Now.Date;
            tarea.HoraRegistro = 1;
            _context.Tarea.Add(tarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarea", new { id = tarea.Id }, tarea);
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var tarea = await _context.Tarea.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tarea.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaExists(int id)
        {
            return _context.Tarea.Any(e => e.Id == id);
        }
    }
}
