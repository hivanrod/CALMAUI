using Calendario2.Services;
using Microsoft.AspNetCore.Components;

namespace Calendario2.Pages
{
    // TODO : 02/Ene/2022 2.19pm : Hacer las otras partes de CRUD de calendario

    public class CalendarioComponentBase : ComponentBase
    {
        [Inject]
        public CitasServices citasServices { get; set; }
        [Parameter]
        public DateTime fechahoy { get; set; } = DateTime.Now;
        public DateTime hoy = DateTime.Now;
        [Parameter]
        public short dianumero { get; set; }

        //[Parameter]
        //  public string dianombre { get; set; } = fechahoy.ToShortTimeString();
        [Parameter]
        public short semana { get; set; } = 0;
        [Parameter]
        public short mes { get; set; } = 0;
        [Parameter]
        public short ano { get; set; } = 0;

        //dianumero = 1; //(0Int16)(DateTime hoy). 

    }
}
