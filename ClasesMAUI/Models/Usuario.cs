namespace ClasesMAUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Required( ErrorMessage = "Se debe poner in guid de string de usuario")]
        [StringLength(100)]
        public string Id { get; set; }
        [StringLength(500)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [StringLength(500)]
        public string CorreoElectronico { get; set; }
        [JsonIgnore]

        public virtual ICollection<Tema> Temas { get; set; }
    }
}
