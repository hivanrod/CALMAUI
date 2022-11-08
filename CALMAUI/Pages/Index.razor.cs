using Microsoft.AspNetCore.Components;

namespace CALMAUI.Pages
{
    public class IndexBase : ComponentBase
    {
        public enum MODE { Día, Mes, Año };
        public MODE mode = MODE.Día;

        public async Task Cambio(MODE mODE)
        {

            //Xcursor(id);
            //AddBool = false;
            //EditBool = true;
            mode = mODE;
        }

    }
}
