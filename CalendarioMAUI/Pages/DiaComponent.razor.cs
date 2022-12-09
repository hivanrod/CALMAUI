using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CalendarioMAUI.Services;
using ClasesMAUI.Models;

namespace CalendarioMAUI.Pages
{
    public class DiaComponentBase : ComponentBase
    {

        [Inject]
        public IJSRuntime Js { get; set; }
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
        public string ClassFocus { get; set; } = "";
        [Parameter]
        public string fecha { get; set; }
        [Parameter]
        public string fecha1 { get; set; }
        [Parameter]
        public string fecha2 { get; set; }
        [Parameter]
        public string hoy { get; set; }
        [Parameter]
        public string tarde { get; set; }
        [Parameter]
        public short h { get; set; }
        [Parameter]
        public short hact { get; set; }
        [Parameter]
        public int desfase { get; set; }
        [Parameter]
        public int horaactual { get; set; }
        [Parameter]
        public int horaaplica { get; set; }
        [Parameter]
        public bool bolcrea { get; set; } = false;
        [Parameter]
        public string dialargo { get; set; } = DateTime.Now.ToLongDateString();
        [Parameter]
        public DateTime dia { get; set; } = DateTime.Now;

        protected ElementReference elementToFocus;
        //[Parameter]
        //public Int16 horas { get; set; } =

        [SupplyParameterFromQuery]
        public string Fecha { get; set; }


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

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                // await Js.InvokeVoidAsync("focusElement", "elementToFocus");
                //await Js.InvokeVoidAsync("exampleJsFunctions", elementToFocus);
                // await elementToFocus.FocusAsync();
                //await Js.InvokeVoidAsync("eval", $@"document.getElementById(""elementToFocus"").focus()");
                // await Js.InvokeVoidAsync("alert", "BIENVENIDO AL CALENDARIO!");
                //if (elementToFocus.Element != null)
                //    await elementToFocus.Element.Value.FocusAsync();
                //await Js.InvokeVoidAsync("exampleJsFunctions.focusElement", elementToFocus);
                await elementToFocus.FocusAsync();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (!String.IsNullOrEmpty(Fecha))
                fecha = Fecha;
            else
                fecha = DateTime.Now.ToShortDateString();
 
            await load(fecha);
            hoy = DateTime.Now.ToString();
            //await load();
            temas = await temasServices.GetTemasAsync();
            await elementToFocus.FocusAsync();

        }

        public async Task load(string fecha, int page = 1, int quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            if (!String.IsNullOrEmpty(Fecha)) { 
                fecha = Convert.ToDateTime(Convert.ToDateTime(Fecha).ToString()).Year.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(Fecha).ToString()).Month.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(Fecha).ToString()).Day.ToString();

            }
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
