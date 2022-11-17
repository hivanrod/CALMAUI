using CALMAUI.Models;
using Microsoft.AspNetCore.Components;
using CALMAUI.Services;

namespace CALMAUI.Pages
{
    public class DiaComponentBase : ComponentBase
    {

        [Inject]
        public NavigationManager navigation { get; set; }
        [Inject]
        public CitasServices citasServices { get; set; }
        [Inject]
        public TareasServices tareasServices { get; set; }
        [Inject]
        public TemasServices temasServices { get; set; }
        public Cita[] citas { get; set; }
        public Tarea[] tareas { get; set; }
        public Tema[] temas { get; set; }
        public Tarea[] tareastodas { get; set; }
        [Parameter]
        public string ClassHora { get; set; } = "";
        [Parameter]
        public string hoy { get; set; }
        [Parameter]
        public int desfase { get; set; }
        [Parameter]
        public int horaactual { get; set; }
        [Parameter]
        public int horaaplica { get; set; }
        [Parameter]
        public string fecha { get; set; }
        [Parameter]
        public string fecha1 { get; set; }
        [Parameter]
        public string fecha2 { get; set; }
        [Parameter]
        public bool bolcrea { get; set; } = false;


        [Parameter]
        public string dialargo { get; set; } = DateTime.Now.ToLongDateString();
        [Parameter]
        public DateTime dia { get; set; } = DateTime.Now;
        //[Parameter]
        //public Int16 horas { get; set; } =

        public enum MODE { Día, Mes, Año };
        public MODE mode = MODE.Día;
        [Parameter]
        public int i { get; set; } = 0;
        [Parameter]
        public int i2 { get; set; } = 0;
        [Parameter]
        public List<string> Horas { get; set; } = new(new string[] { "MADRUGADA", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00M", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "NOCHE" });
        [Parameter]
        public List<string> Mes { get; set; } = new(new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" });

        protected override async Task OnInitializedAsync()
        {
            await load(DateTime.Now.ToShortDateString());
            hoy = DateTime.Now.ToString();
            //await load();
            temas = await temasServices.GetTemasAsync();
        }

        public async Task load(string fecha, int page = 1, int quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            this.fecha = fecha;

            if (!string.IsNullOrEmpty(fecha))
            {
                // fechas BLAZOR SOLO
                fecha1 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Year.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Month.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Day.ToString();
                fecha2 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Year.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Month.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Day.ToString();

                //FECHAS MAUI
                //fecha1 = "10/22/2022";
                //Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Month.ToString() + "/" +
                //Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Day.ToString() + "/" +
                //Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Year.ToString();
                //fecha2 = "10/24/2022";
                //Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Month.ToString() + "/" +
                //Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Day.ToString() + "/" +
                //Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Year.ToString();
                var citas2 = await citasServices.GetCitasAsync();
                citas = await citasServices.GetCitasFechaAsync(fecha);
                //var fecha1 = Convert.ToDateTime(fecha).Date;
                //citas = citas2.Where(x => x.FechaHora.Value.Date == fecha1);
                tareas = await tareasServices.GetTareasFechaAsync(fecha);
            }
            else
            {
                citas = await citasServices.GetCitasAsync();
                tareastodas = await tareasServices.GetTareasAsync();
            }
            //citas = await citasServices.GetCitasFechaAsync(fecha);
            //PrioridadContext = new EditContext(Prio);

        }

        public async Task loadCitasFecha(string fecha, int? page = 1, int? quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            this.fecha = fecha;
            if (!string.IsNullOrEmpty(fecha))
            {
                fecha1 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Year.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Month.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Day.ToString();
                fecha2 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Year.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Month.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Day.ToString();
                // var citas2 = await citasServices.GetCitasAsync();
                citas = await citasServices.GetCitasFechaAsync(fecha);
                dialargo = Convert.ToDateTime(fecha).ToLongDateString();
                //var fecha1 = Convert.ToDateTime(fecha).Date;
                //citas = citas2.Where(x => x.FechaHora.Value.Date == fecha1);
                tareas = await tareasServices.GetTareasFechaAsync(fecha);

            }
            else
            {
                citas = await citasServices.GetCitasAsync();
                tareastodas = await tareasServices.GetTareasAsync();

                //tareasServices = 
            }
            //citas = await citasServices.GetCitasFechaAsync(fecha);
            //PrioridadContext = new EditContext(Prio);

        }
        public async Task AgregaCita(int i)
        {
            bolcrea = true;
            i2 = i;
        }

    }
}
