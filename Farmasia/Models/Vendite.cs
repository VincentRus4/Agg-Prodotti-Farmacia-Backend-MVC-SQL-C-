namespace Farmasia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendite")]
    public partial class Vendite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVendita { get; set; }

        [StringLength(20)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Cognome { get; set; }

        public int IdProdotto { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Data { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
