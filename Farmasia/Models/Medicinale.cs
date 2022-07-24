namespace Farmasia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicinale")]
    public partial class Medicinale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMedicinale { get; set; }

        [StringLength(20)]
        public string NumeroRicetta { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; }
    }
}
