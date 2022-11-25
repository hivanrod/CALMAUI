using Calendario2.Models;
using Microsoft.AspNetCore.Components;
using Calendario2.Services;
using Microsoft.JSInterop;

namespace Calendario2.Pages
{
    public class MesComponentBase : ComponentBase
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

        [Parameter]
        public string fecha { get; set; }
        [Parameter]
        public string fecha1 { get; set; }
        [Parameter]
        public string fecha2 { get; set; }
        [Parameter]
        public string meslargo { get; set; } = DateTime.Now.ToShortDateString();
        [Parameter]
        public string hoy { get; set; }
        [Parameter]
        public int mes { get; set; }
        [Parameter]
        public int dia { get; set; }
        [Parameter]
        public int ano { get; set; }
        public int diasemanainicia { get; set; }
        public int diasemanatermina { get; set; }
        public List<string> Mes = new List<string>(new string[] { "", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" });
        public List<string> Semana = new List<string>(new string[] { "", "1", "2", "3", "4", "5" });


        protected override async Task OnInitializedAsync()
        {
            await load(DateTime.Now.ToShortDateString());
            hoy = DateTime.Now.Date.ToString();
            //hoy = DateTime.Now.ToString();
            ////await load();
            //temas = await temasServices.GetTemasAsync();
        }

        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }
        public async Task Navigate(string url)
        {
            navigation.NavigateTo(url);
        }
        public async Task load(string fecha, int page = 1, int quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            this.fecha = fecha;
            
            // este funciona en maui  var d = Convert.ToDateTime(fecha.ToString()).Month.ToString() + "/01/" + Convert.ToDateTime(fecha.ToString()).Year.ToString();
            var d = "01/" + Convert.ToDateTime(fecha.ToString()).Month.ToString() + "/" +  Convert.ToDateTime(fecha.ToString()).Year.ToString();
            diasemanainicia = (int)Convert.ToDateTime(d).DayOfWeek;
            mes = Convert.ToDateTime(fecha.ToString()).Month;
            ano = Convert.ToDateTime(fecha.ToString()).Year;
            if (diasemanainicia == 0)
            {
                diasemanainicia = 7;
            }
            //diasemanainicia = diasemanainicia == 0 ? diasemanainicia = 7 : diasemanainicia = (int)Convert.ToDateTime(d).DayOfWeek;

            if (!string.IsNullOrEmpty(fecha))
            {

                // fechas BLAZOR SOLO
                fecha1 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Year.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Month.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(-1).ToString()).Day.ToString();
                fecha2 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Year.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Month.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddDays(1).ToString()).Day.ToString();



                //fecha1 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(-1).ToString()).Year.ToString() + "-" +
                //   Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(-1).ToString()).Month.ToString() + "-" +
                //   Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(-1).ToString()).Day.ToString();
                //fecha2 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(1).ToString()).Year.ToString() + "-" +
                //    Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(1).ToString()).Month.ToString() + "-" +
                //    Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(1).ToString()).Day.ToString();
                // var citas2 = await citasServices.GetCitasAsync();
                citas = await citasServices.GetCitasFechaAsync(fecha);
                //var fecha1 = Convert.ToDateTime(fecha).Date;
                //citas = citas2.Where(x => x.FechaHora.Value.Date == fecha1);
                tareas = await tareasServices.GetTareasFechaAsync(fecha);
                meslargo = Convert.ToDateTime(fecha).Month.ToString();
                mes = Convert.ToDateTime(fecha).Month;

            }
            else
            {
                citas = await citasServices.GetCitasAsync();
                tareas = await tareasServices.GetTareasAsync();
            }
            //citas = await citasServices.GetCitasFechaAsync(fecha);
            //PrioridadContext = new EditContext(Prio);

        }



        public async Task loadCitasFecha(string fecha, int? page = 1, int? quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            this.fecha = fecha;
            var d = Convert.ToDateTime(fecha.ToString()).Month.ToString() + "/01/" + Convert.ToDateTime(fecha.ToString()).Year.ToString();
            //var d = "01/" + Convert.ToDateTime(fecha.ToString()).Month.ToString() + "/" +  Convert.ToDateTime(fecha.ToString()).Year.ToString();
            diasemanainicia = (int)Convert.ToDateTime(d).DayOfWeek;
            mes = Convert.ToDateTime(fecha.ToString()).Month;
            ano = Convert.ToDateTime(fecha.ToString()).Year;

            if (diasemanainicia == 0)
            {
                diasemanainicia = 7;
            }

            if (!string.IsNullOrEmpty(fecha))
            {
                fecha1 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(-1).ToString()).Year.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(-1).ToString()).Month.ToString() + "-" +
                   Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(-1).ToString()).Day.ToString();
                fecha2 = Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(1).ToString()).Year.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(1).ToString()).Month.ToString() + "-" +
                    Convert.ToDateTime(Convert.ToDateTime(fecha).AddMonths(1).ToString()).Day.ToString();
                // var citas2 = await citasServices.GetCitasAsync();
                citas = await citasServices.GetCitasFechaAsync(fecha);
                meslargo = Convert.ToDateTime(fecha).Month.ToString();
                //var fecha1 = Convert.ToDateTime(fecha).Date;
                //citas = citas2.Where(x => x.FechaHora.Value.Date == fecha1);
                tareas = await tareasServices.GetTareasFechaAsync(fecha);
                mes = Convert.ToDateTime(fecha).Month;

            }
            else
            {
                citas = await citasServices.GetCitasAsync();
                tareas = await tareasServices.GetTareasAsync();

                //tareasServices = 
            }
            //citas = await citasServices.GetCitasFechaAsync(fecha);
            //PrioridadContext = new EditContext(Prio);

        }

    }



}
