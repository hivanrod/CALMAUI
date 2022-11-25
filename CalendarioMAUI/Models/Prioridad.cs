using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarioMAUI.Models
{

    [Table("Prioridad")]
    public partial class Prioridad
    {
        public Prioridad()
        {
            //Temas = new HashSet<Tema>();
            //    Citas = new HashSet<Cita>();
        }
        public int? Id { get; set; }

        [Required(ErrorMessage = "Debe poner un UserId")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Debe poner un Nombre de hasta 2000 caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo 3 Caracteres.")]
        [StringLength(2000, ErrorMessage = "El Nombre no puede tener mas de 2000 caracteres.")]
        public string Nombre { get; set; }

        public short? Orden { get; set; }

        public virtual Tema Temas { get; set; }
    }
}
