using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalCore23.Models
{

    [Table("Cita")]
    public partial class Cita
    {
        //public Cita()
        //{
        //    this.Usuario = new HashSet<Usuario>();
        //    this.Prioridad = new HashSet<Prioridad>();
        //    //    //this.MateriaPrimaxProceso = new HashSet<MateriaPrimaxProceso>();
        //    //    //this.Procesos1 = new HashSet<Procesos>();
        //}
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int IdImportancia { get; set; }
        [Required]
        [MaxLength(2000, ErrorMessage = "Maximo 2000 Caracteres")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }
        public int Hora { get; set; }
        // RUIDO : 
        public bool Verificado { get; set; } = false;

        public int? IdUsuario { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:SS}", ApplyFormatInEditMode = true)]
        public DateTime? VerificaFechaHora { get; set; }

        [MaxLength(2000, ErrorMessage = "Solo 2000 caracteres")]
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

        public int? Total { get; set; }

        public int? Pasadas { get; set; }

        public int? Hoy { get; set; }

        public int? Futuras { get; set; }
        public int? Archivos { get; set; }

        public int? ContactoId { get; set; }
        public int? PrioridadId { get; set; }

        public int? UsuarioId { get; set; }
        [Required(ErrorMessage = "Debe poner un Tema")]
        public int? TemaId { get; set; }
        public int? TareaId { get; set; }

        //public virtual Contacto Contacto { get; set; }

        //public virtual Prioridad Prioridad { get; set; }
        ////public virtual ICollection<Prioridad> Prioridad { get; set; }

        //public virtual Usuario Usuario { get; set; }
        ////public virtual ICollection<Usuario> Usuario { get; set; }
        //public virtual Tema Tema { get; set; }
        //public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
