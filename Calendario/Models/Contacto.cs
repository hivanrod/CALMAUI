namespace Calendario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contactos")]
    public partial class Contacto
    {
        //public Contacto()
        //{
        //    Temas = new HashSet<Tema>();
        //}
        public int Id { get; set; }
        [Required, MinLength(3, ErrorMessage = "Minimo 3 caracteres"), MaxLength(500, ErrorMessage = "Debe tenes máximo 500 caracteres.")]
        public string Nombres { get; set; }
        [MinLength(3, ErrorMessage = "Minimo 3 caracteres"), MaxLength(500, ErrorMessage = "Debe tenes máximo 500 caracteres.")]
        public string Apellidos { get; set; }
        [MaxLength(500, ErrorMessage = "Debe tenes máximo 500 caracteres.")]
        public string Telefono { get; set; }
        [MaxLength(500, ErrorMessage = "Debe tenes máximo 500 caracteres.")]
        public string Direccion { get; set; }
        [Required, EmailAddress, MaxLength(500, ErrorMessage = "Debe tenes máximo 500 caracteres.")]
        public string CorreoElectronico { get; set; }
        [MaxLength(500, ErrorMessage = "Debe tenes máximo 500 caracteres.")]
        public string Empresa { get; set; }
        [MaxLength(2000, ErrorMessage = "Debe tenes máximo 2000 caracteres.")]
        public string Notas { get; set; }
        public string IdAspNetUsers { get; set; }

        //public virtual ICollection<Tema>? Temas { get; set; }
    }
}
