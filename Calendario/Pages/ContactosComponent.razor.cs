using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Calendario.Services;
using Calendario.Models;

namespace Calendario.Pages
{
    public class ContactosComponentBase : ComponentBase
    {
        [Inject]
        ContactosServices contactosServices { get; set; }
        [Parameter]
        public Contacto contacto { get; set; }
        [Parameter]
        public Contacto[] contactos { get; set; }
        public enum MODE { none, List, EditDelete, Insert };
        public MODE mode = MODE.List;
        [Parameter] public int exis { get; set; } = 250;
        [Parameter] public int ye { get; set; } = 250;

        // Edit
        [Parameter]
        public EditContext ContactoEditContext { get; set; }
        public Contacto Contacto1 = new Contacto()
        {
            Id = 0,
            Nombres = "",
            Apellidos = "",
            Direccion = "",
            CorreoElectronico = "",
            Empresa = "",
            Telefono = "",
            Notas = "",
            IdAspNetUsers = ""
        };
        // Insert
        [Parameter]
        public EditContext ContactoInsertContext { get; set; }
        public Contacto Contacto2 = new Contacto()
        {
            Nombres = "",
            Apellidos = "",
            Direccion = "",
            CorreoElectronico = "",
            Empresa = "",
            Telefono = "",
            Notas = "",
            IdAspNetUsers = ""
        };



        protected override async Task OnInitializedAsync()
        {
            await load();
            //hoy = DateTime.Now.ToString();
            //await load();
        }

        public async Task load(int? page = 1, int? quantityPerPage = 1, string UsuarioId = "err56yh")
        {
            //this.fecha = fecha;
            contactos = await contactosServices.GetContactosAsync();
            ContactoInsertContext = new EditContext(Contacto2);

        }

        public async Task Insert()
        {
            //prioridad = Prio;
            await contactosServices.InsertContactosAsync(Contacto2);
            // ClearFields();
            await load();
            mode = MODE.List;
        }

        protected void Listar()
        {
            //   ClearFields();
            mode = MODE.List;
        }

        public async Task Show(string id)
        {

            //PrioridadEditContext = new EditContext(Prio2);

            ////Xcursor(id);
            contacto = await contactosServices.GetContactoAsync(id);
            Contacto1 = contacto;
            ContactoEditContext = new EditContext(Contacto1);
            //Prio2 = prioridad;
            //AddBool = false;
            //EditBool = true;
            mode = MODE.EditDelete;
        }
        protected async Task Update()
        {
            //if (!String.IsNullOrEmpty(submit.ToString()))
            //{
            //    switch (submit)
            //    {
            //        case "modificar":
            await contactosServices.UpdateContactosAsync(Contacto1.Id.ToString(), Contacto1);
            //        break;
            //    case "borrar":
            //        await citasServices.DeleteCitasAsync(cita.Id.ToString(), Cita1);
            //        break;
            //}
            //}
            contacto = Contacto1;
            //var strdate = new DateTime cita.FechaHora;
            //var arrdate = strdate.Split('/');
            //var arrdate2 = arrdate[2].Split(' ');
            //var arrdate3 = arrdate2[1].Split(':');
            //var date1 = new DateTime(Convert.ToInt32(arrdate2[0]), Convert.ToInt32(arrdate[1]), Convert.ToInt32(arrdate[0]), Convert.ToInt32(arrdate3[0]), Convert.ToInt32(arrdate3[1]), Convert.ToInt32(arrdate3[2]));
            //var date1 = new DateTime(Convert.ToInt32(arrdate2[0]), Convert.ToInt32(arrdate[1]), Convert.ToInt32(arrdate[0]), Convert.ToInt32(arrdate3[0]), Convert.ToInt32(arrdate3[1]), Convert.ToInt32(arrdate3[2]));
            //cita.FechaHora = strdate;
            //            ClearFields();
            await load();
            //AddBool = false;
            //EditBool = false;
            mode = MODE.List;
        }

        protected async Task Delete(string id)
        {
            await contactosServices.DeleteContactosAsync(id);
            //ClearFields();
            StateHasChanged();
            await load();
            mode = MODE.List;
        }


        public async Task Cambio(MODE mODE)
        {

            //Xcursor(id);
            //AddBool = false;
            //EditBool = true;
            mode = mODE;
        }

        protected void Cierra()
        {
            //EditBool = false;
            //AddBool = false;
            mode = MODE.List;
        }

        public async Task OnElementClick(MouseEventArgs e)
        {
            //*var result = await JSRuntime.InvokeAsync<BoundingClientRect>("MyDOMGetBoundingClientReact", e.elementId);

            exis = (int)e.ClientX;// - result.Left);
            ye = (int)e.ClientY - 100;

            // now you can work with the position relative to the element.
        }

        protected void Add()
        {
            //ClearFields();
            ContactoInsertContext = new EditContext(Contacto2);

            mode = MODE.Insert;
        }


    }
}
