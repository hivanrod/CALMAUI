using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using ClasesMAUI.Models;
using ApiCalCore2.Data;

namespace ApiCalCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        CultureInfo provider = CultureInfo.InvariantCulture;
        public CitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCita()
        {
            return await _context.Cita.OrderBy(x => x.Verificado).ThenBy(x => x.TemaId).ThenBy(x => x.Fecha).ThenBy(x => x.PrioridadId).ToListAsync();
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _context.Cita.FindAsync(id);

            if (cita == null)
            {
                return NotFound();
            }

            return cita;
        }
        // GET: api/Citas/tema/5
        [HttpGet("tema/{id}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitasTema(int id)
        {
            // var cita = await _context.Cita.FindAsync(id);
            var cita = await _context.Cita.Where(x => x.TemaId == id).OrderByDescending(y => y.Fecha).ToListAsync();

            if (cita == null)
            {
                return NotFound();
            }

            return cita;
        }

        // GET: api/Citas/Historico/5
        [HttpGet("Historico/{id}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitasHistorico(string id)
        {
            return await _context.Cita.Where(x => x.TemaId == Convert.ToInt32(id)).OrderByDescending(x => x.Fecha).ToListAsync();
        }


        // GET: api/Citas/Fecha/{fecha}
        [HttpGet("Fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitasFecha(string fecha)
        {
            if (fecha == null)
            {
                throw new ArgumentNullException(nameof(fecha));
            }
            else
            {
                var fecha2 = Convert.ToDateTime(fecha.Replace("'", ""));
                var cita2 = await _context.Cita.Where(x => (x.Fecha == fecha2)).OrderBy(x => x.Verificado).ThenBy(x => x.TemaId).ThenBy(x => x.Fecha).ThenBy(x => x.IdImportancia).ToListAsync();
                var cita = cita2;
                //var cita = await _context.Cita.ToListAsync();

                if (cita != null)
                {
                    return cita;
                }
                return cita;
            }
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.Id)
            {
                return BadRequest();
            }
            //var strdate = cita.FechaHora.Value.ToString();

            // cita.FechaHora = DateTime.ParseExact(strdate, "yyyy-MM-ddTHH:mm:ssZ", provider); 
            //cita.FechaHora = DateTime.Parse(strdate, System.Globalization.CultureInfo.CurrentCulture);
            //            cita.FechaHora = DateTime.Parse(strdate, System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(id))
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

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            //var strdate = cita.FechaHora.ToString();
            ////var arrdate = strdate.Split('/');   
            ////var arrdate2 = arrdate[2].Split(' ');
            ////var arrdate3 = arrdate2[1].Split(':');
            ////var date1 = new DateTime(Convert.ToInt32(arrdate2[0]), Convert.ToInt32(arrdate[1]), Convert.ToInt32(arrdate[0]), Convert.ToInt32(arrdate3[0]), Convert.ToInt32(arrdate3[1]), Convert.ToInt32(arrdate3[2]));
            //cita.FechaHora = DateTime.ParseExact(strdate, "yyyy-MM-ddTHH:mm:ssZ",   provider);
            // cita.FechaHora = DateTime.Parse(strdate, System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
            cita.Fecha = Convert.ToDateTime(cita.Fecha).Date;
            _context.Cita.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCita", new { id = cita.Id }, cita);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(string id)
        {
            var cita = await _context.Cita.FindAsync(Convert.ToInt32(id));
            if (cita == null)
            {
                return NotFound();
            }

            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.Id == id);
        }

    }
}
