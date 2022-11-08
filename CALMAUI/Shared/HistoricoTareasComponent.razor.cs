using CALMAUI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using CALMAUI.Services;

namespace CALMAUI.Shared
{
    public class HistoricoTareasComponentBase : ComponentBase
    {
        [Inject]
        RepeticionesServices repeticionesServices { get; set; }
        [Inject]
        TareasServices tareasServices { get; set; }
        [Inject]
        CitasServices citasServices { get; set; }

        [Inject]
        TipoRepeticionesServices tiporepeticionesServices { get; set; }
        [Inject]
        TipoObjetosServices tipoObjetosServices { get; set; }
        [Parameter]
        public int ObjetoId { get; set; }
        [Parameter]
        public int TemaId { get; set; }

        [Parameter]
        public int RepeticionId { get; set; }
        [Parameter]
        public int TipoObjetoId { get; set; }
        [Parameter]
        public int TipoRepeticionId { get; set; }
        [Parameter]
        public bool Repite { get; set; } = false;
        [Parameter]
        public Repeticion[] repeticiones { get; set; }
        [Parameter]
        public Tema[] temas { get; set; }
        [Parameter]
        public Repeticion[] repeticionesCitas { get; set; }
        [Parameter]
        public Repeticion[] repeticionesTareas { get; set; }
        [Parameter]
        public Cita[] historicoCitas { get; set; }
        [Parameter]
        public Tarea[] historicoTareas { get; set; }
        [Parameter]
        public Repeticion repeticion { get; set; }
        [Parameter]
        public bool Historia { get; set; } = false;
        [Parameter]
        public string HistoricoT { get; set; } = "0";
        [Parameter]
        public string HistoricoC { get; set; } = "0";
        [Parameter]
        public bool Historia_citas { get; set; } = false;
        [Parameter]
        public bool Historia_tareas { get; set; } = false;
        [Parameter] public int exis { get; set; } = 250;
        [Parameter] public int ye { get; set; } = 250;

        //// Edit
        //[Parameter]
        //public EditContext RepeticionEditContext { get; set; }
        //public Repeticion repeticionE = new Repeticion()
        //{
        //    Id = 0,
        //    IdObjeto = 0,
        //    IdTipoObjeto = 0,   
        //    TipoObjetoId = 0,
        //    IdTipoRepeticion = 0,
        //    TiposRepeticionId = 0,
        //    RepeticionesPeriodo = 0,
        //    PrioridadId = 0,
        //    FechaHoraRegistro = DateTime.Now.Date,
        //    FechaInicio = DateTime.Now.Date,
        //    HoraInicio = 0,
        //    FechaFinaliza= DateTime.Now.Date,
        //    HoraFinaliza = 0,
        //    Notas = ""
        //};
        // Insert
        //[Parameter]
        //public EditContext RepeticionInsertContext { get; set; }
        //public Repeticion repeticionI = new Repeticion()
        //{
        //    IdObjeto = 0,
        //    IdTipoObjeto = 0,
        //    TipoObjetoId = 0,
        //    IdTipoRepeticion = 0,
        //    TiposRepeticionId = 0,
        //    RepeticionesPeriodo = 0,
        //    PrioridadId = 0,
        //    FechaHoraRegistro = DateTime.Now,
        //    FechaInicio = DateTime.Now.Date,
        //    HoraInicio = 0,
        //    FechaFinaliza = DateTime.Now.Date,
        //    HoraFinaliza = 0,
        //    Notas = ""
        //};


        public List<string> Horas = new List<string>(new string[] { "MADRUGADA", "7:00AM", "8:00AM", "9:00AM", "10:00AM", "11:00AM", "12:00M", "1:00PM", "2:00PM", "3:00PM", "4:00PM", "5:00PM", "6:00PM", "NOCHE" });
        public List<string> Mes = new List<string>(new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" });
        public List<string> Objetos = new List<string>(new string[] { "", "Citas", "Tareas" });


        public enum MODE { None, Add, EditDelete };
        public MODE mode = MODE.None;

        protected override async Task OnInitializedAsync()
        {
            load(0, 0);
        }
        public async Task load(int? ObjetoId, int? TipoObjeto, int page = 1, int quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            //prioridades = await prioridadesServices.GetPrioridadesAsync();
            //temas = await temasServices.GetTemasAsync();
            //RepeticionInsertContext = new EditContext(repeticionI);
            //RepeticionEditContext = new EditContext(repeticionE);
            //citas = await citasServices.GetCitasAsync();
            //tareas = await tareasServices.GetTareasAsync();
            //repeticiones = await repeticionesServices.GetRepeticionesAsync();
            //tipoObjetos = await tipoObjetosServices.GetTipoObjetoAsync();
            //tipoRepeticiones = await tiporepeticionesServices.GetTipoRepeticionesAsync();
            HistoricoT = historicoTareas.Count().ToString();
            //HistoricoC = historicoCitas.Count().ToString(); 
        }


        public async Task MuestraRepeticiones(int? Objeto)
        {
            Repite = Repite == true ? Repite = false : Repite = true;
        }
        public async Task MuestraHistoria(int ObjetoId, int? idTipoObjeto)
        {
            Historia = Historia == true ? Historia = false : Historia = true;
            //switch (idTipoObjeto)
            //{
            //    case 1:
            //repeticionE.IdObjeto = repeticion.;
            //repeticion.CitaId = repeticion.IdObjeto;
            //         repeticionesCitas = await repeticionesServices.GetRepeticionesCitaAsync(ObjetoId);
            //    //   break;
            ////    //case 2:
            ////        repeticion.TareaId = repeticion.IdObjeto;
            //        repeticionesTareas = await repeticionesServices.GetRepeticionesTareaAsync(ObjetoId);
            ////    break;
            //}


        }

        public async Task MuestraHistoria_citas(int ObjetoId, int? idTipoObjeto)
        {
            Historia_citas = Historia_citas == true ? Historia_citas = false : Historia_citas = true;
            //switch (idTipoObjeto)
            //{
            //    case 1:
            //repeticionE.IdObjeto = repeticion.;
            //repeticion.CitaId = repeticion.IdObjeto;
            //historicoCitas = await citasServices.GetCitasHistoricoAsync(ObjetoId.ToString());
            //   break;
            //    //case 2:
            //        repeticion.TareaId = repeticion.IdObjeto;
            // repeticionesTareas = await repeticionesServices.GetRepeticionesTareaAsync(ObjetoId);
            ////    break;
            //}


        }
        public async Task MuestraHistoria_tareas(int ObjetoId, int? idTipoObjeto)
        {
            Historia_tareas = Historia_tareas == true ? Historia_tareas = false : Historia_tareas = true;
            //switch (idTipoObjeto)
            //{
            //    case 1:
            //repeticionE.IdObjeto = repeticion.;
            //repeticion.CitaId = repeticion.IdObjeto;
            //  historicoTareas = await tareasServices.GetTareasHistoricoAsync(ObjetoId.ToString());
            //   break;
            //    //case 2:
            //        repeticion.TareaId = repeticion.IdObjeto;
            //   historicoTareas = await repeticionesServices.GetRepeticionesTareaAsync(ObjetoId);
            ////    break;
            //}


        }


        public async Task Insert()
        {
            //prioridad = Prio;
            //prioridad.UserId = "6";
            ////prioridad.Id = Guid.NewGuid().ToString();
            ////prioridad.UserId = Prio.UserId.ToString();
            ////prioridad.Orden = Prio.Orden.Value;
            ////prioridad.Nombre = Prio.Nombre.ToString();
            ////prioridad = Prio;
            //repeticionI.TipoObjetoId = repeticionI.IdTipoObjeto;

            //repeticionI.IdTipoRepeticion = repeticionI.TiposRepeticionId;
            //repeticionI.IdObjeto = ObjetoId;


            //await repeticionesServices.InsertRepeticionesAsync(repeticionI);
            ////ClearFields();
            //await load(0,0);
            // mode = MODE.None;
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
            mode = MODE.None;
        }


    }
}
