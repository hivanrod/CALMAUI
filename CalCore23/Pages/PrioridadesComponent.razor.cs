using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using CalCore23.Services;
using CalCore23.Models;
// HECHO : 29-12-2021 2.05am : Las otras partes de CRUD :
// HECHO : 29-12-2021 3.10am : Inserción de forma automatica de validación :
// HECHO : 01-ENE-2022 : 11.42Pm : Ya se ve interfase : Se están haciendo las validaciones de forma para insertar prioridad : 


namespace CalCore23.Pages
{
    public class PrioridadesComponentBase : ComponentBase
    {
        [Inject]
        PrioridadesServices prioridadesServices { get; set; }
        [Inject]
        TemasServices temasServices { get; set; }
        [Inject]
        CitasServices citasServices { get; set; }
        [Inject]
        TareasServices tareasServices { get; set; }

        [Parameter]
        public Prioridad prioridad { get; set; }
        [Parameter]
        public Prioridad[] prioridades { get; set; }
        [Parameter]
        public Tema tema { get; set; }
        [Parameter]
        public Tema[] temas { get; set; }
        [Parameter]
        public Cita[] citas { get; set; }
        [Parameter]
        public Tarea[] tareas { get; set; }

        [Parameter]
        public EditContext PrioridadEditContext { get; set; }
        public Prioridad Prio2 = new Prioridad()
        {
            Id = 0,
            Nombre = "",
            UserId = "6",
            Orden = 0
        };
        [Parameter]
        public EditContext PrioridadContext { get; set; }
        public Prioridad Prio = new Prioridad()
        {

            Nombre = "",
            UserId = "6",
            Orden = 0
        };

        public enum MODE { None, List, Add, EditDelete };
        public MODE mode = MODE.List;

        protected override async Task OnInitializedAsync()
        {
            await load();
        }

        public async Task load(int page = 1, int quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            prioridades = await prioridadesServices.GetPrioridadesAsync();
            temas = await temasServices.GetTemasAsync();
            PrioridadContext = new EditContext(Prio);
            citas = await citasServices.GetCitasAsync();
            tareas = await tareasServices.GetTareasAsync();
        }
        public async Task Show(string id)
        {

            //Xcursor(id);
            prioridad = await prioridadesServices.GetPrioridadAsync(id);
            Prio2 = prioridad;
            PrioridadEditContext = new EditContext(Prio2);
            //AddBool = false;
            //EditBool = true;
            mode = MODE.EditDelete;
        }

        public async Task Insert()
        {
            prioridad = Prio;
            prioridad.UserId = "6";
            //prioridad.Id = Guid.NewGuid().ToString();
            //prioridad.UserId = Prio.UserId.ToString();
            //prioridad.Orden = Prio.Orden.Value;
            //prioridad.Nombre = Prio.Nombre.ToString();
            //prioridad = Prio;
            await prioridadesServices.InsertPrioridadesAsync(prioridad);
            ClearFields();
            await load();
            mode = MODE.List;
        }

        protected void ClearFields()
        {
            //prioridad.Id = string.Empty;
            //prioridad.Nombre = string.Empty;
            //prioridad.Orden = string.Empty;

        }

        protected void Add()
        {
            ClearFields();
            mode = MODE.Add;
        }

        protected void Listar()
        {
            ClearFields();
            mode = MODE.List;
        }

        protected async Task Update()
        {
            await prioridadesServices.UpdatePrioridadesAsync(prioridad.Id.ToString(), prioridad);
            ClearFields();
            await load();
            //AddBool = false;
            //EditBool = false;
            mode = MODE.List;
        }

        protected async Task Delete(string id)
        {
            await prioridadesServices.DeletePrioridadesAsync(id, prioridad);
            ClearFields();
            StateHasChanged();
            await load();
            mode = MODE.List;
        }

    }
}
