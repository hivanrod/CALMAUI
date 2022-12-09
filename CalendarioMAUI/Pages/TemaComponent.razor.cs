using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using CalendarioMAUI.Services;
using ClasesMAUI.Models;

namespace CalendarioMAUI.Pages
{
    // TODO : 29-Dic-2021 : Hacer las otras partes de CRUD :

    public class TemaComponentBase : ComponentBase
    {
        public NavigationManager navigationManager;
        [Parameter]
        [SupplyParameterFromQuery]
        public string Filter { get; set; }
        [Inject]
        TemasServices TemasServices { get; set; }
        [Inject]
        CitasServices CitasServices { get; set; }
        [Parameter]
        public Cita[] historicoCitas { get; set; }
        [Parameter]
        public string historicoT { get; set; }
        [Inject]
        TareasServices TareasServices { get; set; }
        [Parameter]
        public Tarea[] historicoTareas { get; set; }
        [Parameter]
        public string historicoC { get; set; }
        [Inject]
        PrioridadesServices prioridadesServices { get; set; }
        [Parameter]
        public Tema tema { get; set; }
        [Parameter]
        public Tema[] Temas { get; set; }
        [Parameter]
        public Cita[] citas { get; set; }
        [Parameter]
        public Tarea[] tareas { get; set; }
        [Parameter]
        public Prioridad[] Prio { get; set; }
        //  update
        [Parameter]
        public EditContext TemaContext { get; set; }
        public Tema Tema1 = new Tema()
        {
            Id = 0,
            Descripcion = "",
            PrioridadId = 0,
            ContactoId = 0,
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
            UsuarioId = 1
        };
        // Insert
        [Parameter]
        public EditContext TemaEditContext { get; set; }
        public Tema Tema2 = new Tema()
        {
            Descripcion = "",
            PrioridadId = 0,
            ContactoId = 6,
            UserId = "6",
            Notas = "",
            Hoy = 0,
            Pasadas = 0,
            Futuras = 0,
            Ingreso = 0,
            Pagos = 0,
            Presupuesto = 0,
            Compras = 0,
            UsuarioId = 1
        };

        [Parameter] public int exis { get; set; } = 250;
        [Parameter] public int ye { get; set; } = 250;

        public enum MODE { None, List, Add, EditDelete };
        public MODE mode = MODE.List;

        protected override async Task OnInitializedAsync()
        {
            await load("");
        }

        public async Task load(string Filter, int page = 1, int quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            if (!string.IsNullOrEmpty(Filter))
            {
                Temas = await TemasServices.GetTemaPrioridadAsync(Filter);
                //historicoCitas = await CitasServices.GetCitasHistoricoAsync(Tema1.Id.ToString());
                //historicoC = historicoCitas.Count().ToString();
                //historicoTareas = await TareasServices.GetTareasHistoricoAsync(Tema1.Id.ToString());
                //historicoT = historicoTareas.Count().ToString();
            }
            else
            {
                Temas = await TemasServices.GetTemasAsync();
                historicoC = "0";
                historicoT = "0";
                //historicoCitas = await CitasServices.GetCitasHistoricoAsync(Tema1.Id.ToString());
                //historicoC = historicoCitas.Count().ToString();
                //historicoTareas = await TareasServices.GetTareasHistoricoAsync(Tema1.Id.ToString());
                //historicoT = historicoTareas.Count().ToString();
            }

            citas = await CitasServices.GetCitasAsync();
            tareas = await TareasServices.GetTareasAsync();
            Prio = await prioridadesServices.GetPrioridadesAsync();
            TemaContext = new EditContext(Tema1);
            mode = MODE.List;
        }

        //private void NavigatePrioridad()
        //{
        //    navigationManager.NavigateTo("/Tema/?prioid=1");
        //}

        public async Task Show(string id)
        {

            //PrioridadEditContext = new EditContext(Prio2);

            ////Xcursor(id);
            tema = await TemasServices.GetTemaAsync(id);
            historicoCitas = await CitasServices.GetCitasHistoricoAsync(id);
            historicoC = historicoCitas.Count().ToString();
            historicoTareas = await TareasServices.GetTareasHistoricoAsync(id);
            historicoT = historicoTareas.Count().ToString();

            Tema1 = tema;
            TemaEditContext = new EditContext(Tema1);
            //Prio2 = prioridad;
            //AddBool = false;
            //EditBool = true;
            mode = MODE.EditDelete;
        }

        public async Task<int> ShowCita(string id)
        {

            //PrioridadEditContext = new EditContext(Prio2);

            ////Xcursor(id);
            historicoCitas = await CitasServices.GetCitasHistoricoAsync(id);
            historicoC = historicoCitas.Count().ToString();
            //mode = MODE.EditDelete;
            return historicoCitas.Count();
        }

        public async Task Filtro(string id, string Filtro)
        {
            Filter = Filtro;
            //switch (Filter)
            //{
            //    case else : 

            //                break;
            //}
            if (!string.IsNullOrEmpty(id))
            {
                Temas = await TemasServices.GetTemaPrioridadAsync(id);
            }
            else
            {
                Temas = await TemasServices.GetTemasAsync();
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

        protected void Listar()
        {
            ClearFields();
            mode = MODE.List;
        }


        public async Task Insert()
        {
            //prioridad = Prio;
            await TemasServices.InsertTemasAsync(Tema2);
            ClearFields();
            await load("");
            mode = MODE.List;
        }

        protected void ClearFields()
        {
            //prioridad.Id = string.Empty;
            //prioridad.Nombre = string.Empty;
            //prioridad.Orden = string.Empty;
            //tema.Id = 0;
            //tema.Descripcion = string.Empty;
            //tema.PrioridadId = 0;
            //tema.IdPrioridad = 0;
            //tema.ContactoId = 0;
            //tema.UserId = string.Empty;
            //tema.Notas = string.Empty;
            //tema.Hoy = 0;
            //tema.Pasadas = 0;
            //tema.Futuras = 0;
            //tema.Ingreso = 0;
            //tema.Pagos = 0;
            //tema.Presupuesto = 0;
            //tema.Compras = 0;
            //tema.IdUsuario = 0;

        }

        protected void Add()
        {
            ClearFields();
            mode = MODE.Add;
        }

        protected async Task Update()
        {
            await TemasServices.UpdateTemasAsync(Tema1.Id.ToString(), Tema1);
            ClearFields();
            await load("");
            //AddBool = false;
            //EditBool = false;
            mode = MODE.List;
        }

        protected async Task Delete(string id)
        {
            await TemasServices.DeleteTemasAsync(id, tema);
            ClearFields();
            StateHasChanged();
            await load("");
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
