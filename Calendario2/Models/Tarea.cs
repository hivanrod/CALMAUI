using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calendario2.Models
{

    [Table("Tarea")]
    public partial class Tarea
    {
        //public Cita()
        //{
        //    this.Usuario = new HashSet<Usuario>();
        //    this.Prioridad = new HashSet<Prioridad>();
        //    //    //this.MateriaPrimaxProceso = new HashSet<MateriaPrimaxProceso>();
        //    //    //this.Procesos1 = new HashSet<Procesos>();
        //}
        public int Id { get; set; }

        public string UserId { get; set; }

        public int IdImportancia { get; set; } = 2;

        [StringLength(2000)]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRegistro { get; set; }
        public short? HoraRegistro { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInicio { get; set; }
        public short? HoraInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaFinaliza { get; set; }
        public short? HoraFinaliza { get; set; }
        public bool Verificado { get; set; }

        public int? IdUsuario { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:SS}", ApplyFormatInEditMode = true)]
        public DateTime? VerificaFechaHora { get; set; }

        [StringLength(2000)]
        public string Notas { get; set; }
        public int? ContactoId { get; set; }
        public int? CitaId { get; set; }
        [Required(ErrorMessage = "Debe poner una TemaId")]
        public int TemaId { get; set; }
        public int? PrioridadId { get; set; }
        public int? IdTareaPadre { get; set; }

        //public virtual Contacto Contacto { get; set; }

        //public virtual Prioridad Prioridad { get; set; }
        ////public virtual ICollection<Prioridad> Prioridad { get; set; }

        //public virtual Usuario Usuario { get; set; }
        ////public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual Tema Temas { get; set; }
        public virtual Cita Cita { get; set; }
        //public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
