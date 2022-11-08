using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CALMAUI.Models
{

    [Table("Repeticion")]
    public partial class Repeticion
    {
        //public Tema()
        //{
        //    //this.Usuario = new HashSet<Usuario>();
        //    this.Prioridad = new HashSet<Prioridad>();
        //    //    //    //this.MateriaPrimaxProceso = new HashSet<MateriaPrimaxProceso>();
        //    //    //    //this.Procesos1 = new HashSet<Procesos>();
        //}
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe poner un UserId")]
        public int IdObjeto { get; set; }
        public int IdTipoObjeto { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:MM:SS}", ApplyFormatInEditMode = true)]
        public DateTime? FechaHoraRegistro { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInicio { get; set; }
        public int HoraInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaFinaliza { get; set; }
        public int HoraFinaliza { get; set; }

        public int RepeticionesPeriodo { get; set; }
        public int IdTipoRepeticion { get; set; }

        [MaxLength(2000, ErrorMessage = "La Nota no puede tener mas de 2000 caracteres.")]
        public string Notas { get; set; }

        public int? UsuarioId { get; set; } = 0;
        public int? PrioridadId { get; set; } = 0;

        //public  Contacto Contacto { get; set; }

        //public  Prioridad Prioridad2 { get; set; }
        public virtual Prioridad Prioridad { get; set; }
        //public virtual ICollection<Prioridad> Prioridad { get; set; }
        public int? TemaId { get; set; } = 0;
        public virtual Tema Tema { get; set; }
        public int? CitaId { get; set; } = 0;
        public virtual Cita Cita { get; set; }
        public int? TareaId { get; set; } = 0;
        public virtual Tarea Tarea { get; set; }
        public int? TipoObjetoId { get; set; } = 0;
        public virtual TipoObjeto TipoObjeto { get; set; }
        public int TiposRepeticionId { get; set; } = 0;
        public virtual TipoRepeticion TipoRepiticion { get; }
        //public virtual Usuario Usuario { get; set; }
        //public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
