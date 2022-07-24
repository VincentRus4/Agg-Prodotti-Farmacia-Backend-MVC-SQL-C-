using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Farmasia.Models;

namespace Farmasia.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext2")
        {
        }

        public virtual DbSet<Ditta> Ditta { get; set; }
        public virtual DbSet<Medicinale> Medicinale { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<TipoProdotto> TipoProdotto { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vendite> Vendite { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prodotti>()
                .Property(e => e.Cassetto)
                .IsFixedLength();

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.Vendite)
                .WithRequired(e => e.Prodotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoProdotto>()
                .HasMany(e => e.Prodotti)
                .WithRequired(e => e.TipoProdotto)
                .WillCascadeOnDelete(false);
        }
    }
}
