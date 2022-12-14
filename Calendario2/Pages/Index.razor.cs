using Microsoft.AspNetCore.Components;

namespace Calendario2.Pages
{
    public class IndexBase : ComponentBase
    {
        [Parameter]
        public string? fecha { get; set; }
        [Parameter]
        public string hoy { get; set; }
        public enum MODE { Día, Mes, Año };
        public MODE mode = MODE.Día;


        protected override async Task OnInitializedAsync()
        {
            //await load(DateTime.Now.ToShortDateString());
            hoy = DateTime.Now.Date.ToString();
            //hoy = DateTime.Now.ToString();
            ////await load();
            //temas = await temasServices.GetTemasAsync();
        }

        public async Task Cambio(MODE mODE)
        {

            //Xcursor(id);
            //AddBool = false;
            //EditBool = true;
            mode = mODE;
        }

    }
}
