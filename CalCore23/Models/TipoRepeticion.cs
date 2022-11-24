namespace CalCore23.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoRepeticion")]
    public partial class TipoRepeticion
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }

    }
}
