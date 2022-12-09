namespace ClasesMAUI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Archivos")]
    public partial class Archivo
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "No debe poner más de 100 caracteres")]
        public string UserId { get; set; }

        public int? IdTema { get; set; }

        public string Nombre { get; set; }

        //public virtual ICollection<Tema> IdTema { get; set; }


    }
}