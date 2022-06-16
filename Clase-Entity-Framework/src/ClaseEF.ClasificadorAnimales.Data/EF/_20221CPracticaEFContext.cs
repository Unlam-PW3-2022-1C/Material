using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClaseEF.ClasificadorAnimales.Data.EF
{
    public partial class _20221CPracticaEFContext : DbContext
    {
        public _20221CPracticaEFContext()
        {
        }

        public _20221CPracticaEFContext(DbContextOptions<_20221CPracticaEFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<TipoAnimal> TipoAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=2022-1C-Practica-EF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal);

                entity.ToTable("Animal");

                entity.Property(e => e.NombreEspecie)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdTipoAnimalNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdTipoAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_TipoAnimal");
            });

            modelBuilder.Entity<TipoAnimal>(entity =>
            {
                entity.HasKey(e => e.IdTipoAnimal);

                entity.ToTable("TipoAnimal");

                entity.Property(e => e.IdTipoAnimal).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
