using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using Calendario.Services;
using Calendario.Models;

namespace Calendario.Pages
{
    public class TareasComponentBase : ComponentBase
    {
        [Inject]
        public NavigationManager navigation { get; set; }
        [SupplyParameterFromQuery]
        public string Filter { get; set; }

        [Inject]
        CitasServices citasServices { get; set; }
        [Inject]
        TareasServices tareasServices { get; set; }

        [Inject]
        PrioridadesServices prioridadesServices { get; set; }
        [Inject]
        TemasServices temasServices { get; set; }
        [Parameter]
        public object submit { get; set; }
        [Parameter]
        public Cita cita { get; set; }
        [Parameter]
        public Cita[] citastodas { get; set; }
        [Parameter]
        public string? accion { get; set; }
        [Parameter]
        public string? i { get; set; }
        [Parameter]
        public string? fechaviene { get; set; }
        [Parameter]
        public bool boltodas { get; set; }
        [Parameter]
        public Tarea tarea { get; set; }
        [Parameter]
        public Tarea[] tareas { get; set; }
        [Parameter]
        public Cita[] citas { get; set; }
        [Parameter]
        public Tema tema { get; set; }
        [Parameter]
        public Tema[] temas { get; set; }
        //[Parameter]
        //public Prioridad[] Prio { get; set; }
        // -----Update--------
        [Parameter]
        public EditContext TareaContext { get; set; }
        public Tarea Tarea1 = new Tarea()
        {
            Id = 0,
            Descripcion = "",
            IdImportancia = 2,
            //FechaRegistro = DateTime.Now.Date,
            FechaInicio = DateTime.Now.Date,
            FechaFinaliza = DateTime.Now.Date,
            HoraInicio = 0,
            HoraFinaliza = 0,
            //HoraRegistro = 0,
            ContactoId = 6,
            UserId = "6",
            Notas = "",
            //Hoy = 0,
            //Pasadas = 0,
            //Futuras = 0,
            //Ingreso = 0,
            //Pagos = 0,
            //Presupuesto = 0,
            //Compras = 0,
            IdUsuario = 0,
            //UsuarioId = 1,
            //TemaId = 0,
            //CitaId = 0
            IdTareaPadre = 0,
        };
        // --------Insert-----------
        [Parameter]
        public EditContext TareaEditContext { get; set; }
        public Tarea Tarea2 = new Tarea()
        {
            Descripcion = "",
            //FechaRegistro = DateTime.Now.Date,
            FechaInicio = DateTime.Now.Date,
            FechaFinaliza = DateTime.Now.Date,
            HoraInicio = 0,
            HoraFinaliza = 0,
            //HoraRegistro = 0,
            IdImportancia = 2,
            ContactoId = 6,
            UserId = "6",
            Notas = "",
            //  Hoy = 0,
            //  Pasadas = 0,
            //  Futuras = 0,
            //  Ingreso = 0,
            //  Pagos = 0,
            //  Presupuesto = 0,
            //  Compras = 0,
            //  IdUsuario = 0,
            //UsuarioId = 1,
            //TemaId = 0,
            //CitaId= 0
            IdTareaPadre = 0
        };
        [Parameter] public int exis { get; set; } = 250;
        [Parameter] public int ye { get; set; } = 250;
        public enum MODE { None, List, Add, EditDelete };
        public MODE mode = MODE.List;

        public List<string> Horas = new List<string>(new string[] { "MADRUGADA", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00M", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "NOCHE" });
        public List<string> Importancia = new List<string>(new string[] { "ALTA IMPORTANCIA", "MEDIA IMPORTANCIA", "BAJA IMPORTANCIA" });

        protected override async Task OnInitializedAsync()
        {
            await load("");
            temas = await temasServices.GetTemasAsync();
            tareas = await tareasServices.GetTareasAsync();


        }

        public async Task load(string fecha, int? page = 1, int? quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            tareas = await tareasServices.GetTareasAsync();
            citastodas = await citasServices.GetCitasAsync();

            //Prio = await prioridadesServices.GetPrioridadesAsync();
            //Prio = await prioridadesServices.GetPrioridadesCitaAsync();
            //Prio = Importancia; //await prioridadesServices.GetPrioridadesCitaAsync();
            temas = await temasServices.GetTemasAsync();
            TareaContext = new EditContext(Tarea1);

            if (accion != null)
            {
                if (accion.Length > 1)
                {
                    switch (accion)
                    {
                        case "add":
                            Tarea2.HoraInicio = Convert.ToInt16(Horas.IndexOf(i));
                            Tarea2.FechaInicio = Convert.ToDateTime(fechaviene.Replace("-", "/"));
                            Add();
                            //mode= MODE.Add;
                            //var cuant = int(i);
                            //tareas.H.Hora = Horas.IndexOf(i);
                            break;

                        case "edit":
                            //navigation.NavigateTo("/citas/" + accion.ToString() + "/" + i.ToString() );
                            if (i != null)
                            {

                                //Cita1.Id = Int16.Parse(i);
                                //await load();
                                await Show(i);

                                //mode = MODE.EditDelete;
                                //var cuant = int(i);
                                //Cita2.Hora = Horas.IndexOf(i);
                            }

                            break;

                        default:
                            break;
                    }
                }
            }



        }

        public async Task Todas()
        {
            await load("");
            boltodas = false;
        }

        public async Task Filtro(string id, string Filtro)
        {
            Filter = Filtro;
            boltodas = false;
            //switch (Filter)
            //{
            //    case else : 

            //                break;
            //}
            if (!string.IsNullOrEmpty(id))
            {
                tareas = await tareasServices.GettareasTemaAsync(id);
                boltodas = true;
            }
            else
            {
                tareas = await tareasServices.GetTareasAsync();
            }
            //navigationManager.GetUriWithQueryParameters(
            //    new Dictionary<string,object>
            //    {
            //        ["prioid"] = id
            //    }
            //);

            //PrioridadEditContext = new EditContext(Prio2);

            ////Xcursor(id);
            //  mode = MODE.List;
        }



        public async Task Show(string id)
        {

            //PrioridadEditContext = new EditContext(Prio2);

            ////Xcursor(id);
            tarea = await tareasServices.GetTareasAsync(id);
            Tarea1 = tarea;
            TareaEditContext = new EditContext(Tarea1);
            //Prio2 = prioridad;
            //AddBool = false;
            //EditBool = true;
            mode = MODE.EditDelete;
        }

        public async Task Insert()
        {
            //prioridad = Prio;
            await tareasServices.InsertTareasAsync(Tarea2);
            ClearFields();
            //await load("");
            //mode = MODE.List;
            navigation.NavigateTo("/");

        }

        protected void ClearFields()
        {
            //prioridad.Id = string.Empty;
            //prioridad.Nombre = string.Empty;
            //prioridad.Orden = string.Empty;
            //Cita.Id = 0;
            //Cita.Descripcion = string.Empty;
            //Cita.PrioridadId = 0;
            //Cita.IdPrioridad = 0;
            //Cita.ContactoId = 0;
            //Cita.UserId = string.Empty;
            //Cita.Notas = string.Empty;
            //Cita.Hoy = 0;
            //Cita.Pasadas = 0;
            //Cita.Futuras = 0;
            //Cita.Ingreso = 0;
            //Cita.Pagos = 0;
            //Cita.Presupuesto = 0;
            //Cita.Compras = 0;
            //Cita.IdUsuario = 0;

        }

        protected void Add()
        {
            ClearFields();
            if (accion == null)
            {
                accion = "add";
            }
            if (i == null)
            {
                i = Horas[0];
            }
            mode = MODE.Add;
        }

        protected async Task Update()
        {
            await tareasServices.UpdateTareasAsync(Tarea1.Id.ToString(), Tarea1);
            tarea = Tarea1;
            if (accion == null)
            {
                accion = "edit";
            }
            if (i == null)
            {
                i = Horas[0];
            }

            //var strdate = new DateTime cita.FechaHora;
            //var arrdate = strdate.Split('/');
            //var arrdate2 = arrdate[2].Split(' ');
            //var arrdate3 = arrdate2[1].Split(':');
            //var date1 = new DateTime(Convert.ToInt32(arrdate2[0]), Convert.ToInt32(arrdate[1]), Convert.ToInt32(arrdate[0]), Convert.ToInt32(arrdate3[0]), Convert.ToInt32(arrdate3[1]), Convert.ToInt32(arrdate3[2]));
            //cita.FechaHora = strdate;
            //            ClearFields();
            //await load("");
            //AddBool = false;
            //EditBool = false;
            //mode = MODE.List;
            //            navigation.NavigateTo("/?fecha=" + fechaviene.Replace("-", "/"));
            navigation.NavigateTo("/");
        }

        protected async Task Delete(string id)
        {
            await tareasServices.DeleteTareasAsync(id);
            ClearFields();
            StateHasChanged();
            //await load("");
            //mode = MODE.List;
            navigation.NavigateTo("/");
        }

        public async Task OnElementClick(MouseEventArgs e)
        {
            //*var result = await JSRuntime.InvokeAsync<BoundingClientRect>("MyDOMGetBoundingClientReact", e.elementId);

            exis = (int)e.ClientX;// - result.Left);
            ye = (int)e.ClientY - 100;

            // now you can work with the position relative to the element.
        }
        protected void Diario()
        {
            ClearFields();
            navigation.NavigateTo("/");
            //mode = MODE.List;
        }
        protected void Listar()
        {
            ClearFields();
            mode = MODE.List;
        }

        protected void Cierra()
        {
            //EditBool = false;
            //AddBool = false;
            mode = MODE.List;
        }

    }
}
