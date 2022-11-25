namespace Calendario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoObjeto")]
    public partial class TipoObjeto
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }

    }
}
