using CALMAUI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using CALMAUI.Services;
using System.Linq;
using System.Data;

namespace CALMAUI.Pages
{
    // TODO : 29-dic-2021 6.01pm : Hacer las otras partes de CRUD

    public class CitasComponentBase : ComponentBase
    {

        [Inject]
        NavigationManager navigation { get; set; }
        [Inject]
        CitasServices citasServices { get; set; }

        [Inject]
        PrioridadesServices prioridadesServices { get; set; }
        [Inject]
        TemasServices temasServices { get; set; }
        [Inject]
        TareasServices tareasServices { get; set; }
        [Parameter]
        public object submit { get; set; }
        [Parameter]
        public Cita cita { get; set; }
        [Parameter]
        public string? accion { get; set; }
        [Parameter]
        public string? i { get; set; }
        [Parameter]
        public Cita[] citas { get; set; }
        [Parameter]
        public Tema tema { get; set; }
        [Parameter]
        public Tema[] temas { get; set; }
        [Parameter]
        public Tarea[] tareas { get; set; }
        [Parameter]
        public Prioridad[] Prio { get; set; }
        // Update
        [Parameter]
        public EditContext CitaContext { get; set; }
        public Cita Cita1 = new Cita()
        {
            Id = 0,
            Descripcion = "",
            PrioridadId = 1,
            Fecha = DateTime.Now.Date,
            Hora = 0,
            ContactoId = 6,
            Verificado = false,
            UserId = "6",
            Notas = "",
            Hoy = 0,
            Pasadas = 0,
            Futuras = 0,
            Ingreso = 0,
            Pagos = 0,
            Presupuesto = 0,
            Compras = 0,
            IdUsuario = 0,
            UsuarioId = 1,
            TemaId = 0,
            TareaId = 0
        };
        // Insert
        [Parameter]
        public EditContext CitaEditContext { get; set; }
        public Cita Cita2 = new Cita()
        {
            Descripcion = "",
            PrioridadId = 1,
            Fecha = DateTime.Now.Date,
            Hora = 0,
            IdImportancia = 0,
            ContactoId = 6,
            UserId = "6",
            Notas = "",
            Verificado = false,
            //  Hoy = 0,
            //  Pasadas = 0,
            //  Futuras = 0,
            //  Ingreso = 0,
            //  Pagos = 0,
            //  Presupuesto = 0,
            //  Compras = 0,
            //  IdUsuario = 0,
            UsuarioId = 1,
            TemaId = 0,
            TareaId = 0
        };
        [Parameter] public int exis { get; set; } = 250;
        [Parameter] public int ye { get; set; } = 250;
        public enum MODE { None, List, Add, EditDelete };
        public MODE mode = MODE.List;

        public List<string> Horas = new(new string[] { "MADRUGADA", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00M", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "NOCHE" });
        public List<string> Importancia = new(new string[] { "ALTA IMPORTANCIA", "MEDIA IMPORTANCIA", "BAJA IMPORTANCIA" });

        protected override async Task OnInitializedAsync()
        {
            await load();
        }

        public async Task load(int page = 1, int quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            citas = await citasServices.GetCitasAsync();
            //   Prio = Importancia;// await prioridadesServices.GetPrioridadesAsync();
            Prio = await prioridadesServices.GetPrioridadesAsync();
            //Prio = await prioridadesServices.GetPrioridadesCitaAsync();
            temas = await temasServices.GetTemasAsync();
            tareas = await tareasServices.GetTareasActivasAsync();
            CitaContext = new EditContext(Cita1);
            if (accion != null)
            {
                if (accion.Length > 1) 
                {
                    switch (accion)
                    {
                        case "add":
                            //navigation.NavigateTo("/citas/" + accion.ToString() + "/" + i.ToString() );
                            Add();
                            //mode= MODE.Add;
                            //var cuant = int(i);
                            Cita2.Hora = Horas.IndexOf(i);
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
        protected void Listar()
        {
            ClearFields();
            mode = MODE.List;
        }

        public async Task Show(string id)
        {

            //PrioridadEditContext = new EditContext(Prio2);

            ////Xcursor(id);
            cita = await citasServices.GetCitasAsync(id);
            Cita1 = cita;
            CitaEditContext = new EditContext(Cita1);
            //Prio2 = prioridad;
            //AddBool = false;
            //EditBool = true;
            mode = MODE.EditDelete;
        }

        public async Task Insert()
        {
            //prioridad = Prio;
            await citasServices.InsertCitasAsync(Cita2);
            ClearFields();
            await load();
            mode = MODE.List;
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
            mode = MODE.Add;
        }

        protected async Task Update()
        {
            await citasServices.UpdateCitasAsync(Cita1.Id.ToString(), Cita1);
            cita = Cita1;
            await load();
            mode = MODE.List;
        }

        protected async Task Delete(string id)
        {
            await citasServices.DeleteCitasAsync(id);
            ClearFields();
            StateHasChanged();
            //await load();
            mode = MODE.List;
        }

        public async Task OnElementClick(MouseEventArgs e)
        {
            //*var result = await JSRuntime.InvokeAsync<BoundingClientRect>("MyDOMGetBoundingClientReact", e.elementId);

            exis = (int)e.ClientX;// - result.Left);
            ye = (int)e.ClientY - 100;

            // now you can work with the position relative to the element.
        }
        protected void Cierra()
        {
            //EditBool = false;
            //AddBool = false;
            mode = MODE.List;
        }

    }
}
