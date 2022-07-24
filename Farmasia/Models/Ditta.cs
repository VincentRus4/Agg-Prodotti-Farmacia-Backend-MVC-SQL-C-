namespace Farmasia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ditta")]
    public partial class Ditta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDittaFornitrice { get; set; }

        [StringLength(20)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Recapito { get; set; }

        [StringLength(50)]
        public string Indirizzo { get; set; }
    }
}
