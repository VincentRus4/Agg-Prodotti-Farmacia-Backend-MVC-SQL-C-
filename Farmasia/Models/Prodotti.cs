namespace Farmasia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            Vendite = new HashSet<Vendite>();
        }

        [StringLength(20)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Ditta { get; set; }

        [StringLength(150)]
        public string Dettagli { get; set; }

        [StringLength(1)]
        public string Cassetto { get; set; }

        [StringLength(10)]
        public string Armadietto { get; set; }

        public int IdTipo { get; set; }

        [Key]
        public int IdProdotto { get; set; }

        public virtual TipoProdotto TipoProdotto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vendite> Vendite { get; set; }
    }
}
