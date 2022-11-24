using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalCore23.Models
{

    [Table("Tema")]
    public partial class Tema
    {
        //public Tema()
        //{
        //    //this.Usuario = new HashSet<Usuario>();
        //    this.Prioridad = new HashSet<Prioridad>();
        //    //    //    //this.MateriaPrimaxProceso = new HashSet<MateriaPrimaxProceso>();
        //    //    //    //this.Procesos1 = new HashSet<Procesos>();
        //}
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe poner un UserId")]
        public string UserId { get; set; }
        public int? IdImportancia { get; set; }
        [Required(ErrorMessage = "Debe poner una descripción")]
        [MinLength(3, ErrorMessage = "Mínimo 3 Caracteres.")]
        [StringLength(2000, ErrorMessage = "La descripción no puede tener mas de 2000 caracteres.")]
        public string Descripcion { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}  HH:MM:SS", ApplyFormatInEditMode = true)]
        public DateTime? FechaHora { get; set; }

        public bool? Verificado { get; set; }

        public int? IdUsuario { get; set; }

        [DataType(DataType.Date)]
        public DateTime? VerificaFechaHora { get; set; }

        [MaxLength(2000, ErrorMessage = "La Nota no puede tener mas de 2000 caracteres.")]
        public string Notas { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public int? Ingreso { get; set; } = 0;


        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public int? Presupuesto { get; set; } = 0;

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public int? Compras { get; set; } = 0;


        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public int? Pagos { get; set; } = 0;

        public int? IdContacto { get; set; }

        public int? Total { get; set; } = 0;

        public int? Pasadas { get; set; } = 0;

        public int? Hoy { get; set; } = 0;

        public int? Futuras { get; set; } = 0;
        public int? Archivos { get; set; } = 0;

        public int? ContactoId { get; set; } = 0;
        [Required(ErrorMessage = "Debe poner una Prioridad")]
        public int PrioridadId { get; set; } = 0;

        public int? UsuarioId { get; set; } = 0;

        //public  Contacto Contacto { get; set; }

        //public  Prioridad Prioridad2 { get; set; }
        public virtual Prioridad Prioridad { get; set; }
        //public virtual ICollection<Prioridad> Prioridad { get; set; }
        //public Usuario Usuario { get; set; }    
        //public virtual Usuario Usuario { get; set; }
        //public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
