using Microsoft.AspNetCore.Components;

namespace CalendarioMAUI.Pages
{
    public class IndexBase : ComponentBase
    {
        [Parameter]
        public string? Fecha { get; set; } = "";
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
            if(!String.IsNullOrEmpty(Fecha))
            {
                mode = MODE.Día;
            }

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
