using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FacturacionElectronica.Models
{
    public partial class PosDbContext : DbContext
    {
        public PosDbContext()
        {
        }

        public PosDbContext(DbContextOptions<PosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<DocumentosTramas> DocumentosTramas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAP\\DESA;Database=dbAyE;Uid=sa;Pwd=sistemas;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.Property(e => e.IdDocumento).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Caja)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("smalldatetime");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTramaNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdTrama)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documentos_Documentos_Tramas");
            });

            modelBuilder.Entity<DocumentosTramas>(entity =>
            {
                entity.HasKey(e => e.IdTrama);

                entity.ToTable("Documentos_Tramas");

                entity.Property(e => e.IdTrama).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cdr)
                    .HasColumnName("cdr")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Firmaxml).IsUnicode(false);

                entity.Property(e => e.Hash).IsUnicode(false);

                entity.Property(e => e.Json)
                    .HasColumnName("json")
                    .IsUnicode(false);

                entity.Property(e => e.Xml)
                    .HasColumnName("xml")
                    .IsUnicode(false);

                entity.Property(e => e.Xmlzip)
                    .HasColumnName("xmlzip")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
