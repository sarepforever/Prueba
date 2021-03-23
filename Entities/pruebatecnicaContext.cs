using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba.Entities
{
    public partial class pruebatecnicaContext : DbContext
    {
        public pruebatecnicaContext()
        {
        }

        public pruebatecnicaContext(DbContextOptions<pruebatecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arl> Arls { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Contratoslaborale> Contratoslaborales { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Novedadesnomina> Novedadesnominas { get; set; }
        public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql("Server=localhost;Database=pruebatecnica;Uid=postgres;Pwd=ROOT");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Colombia.1252");

            modelBuilder.Entity<Arl>(entity =>
            {
                entity.HasKey(e => e.Idarl)
                    .HasName("arl_pkey");

                entity.ToTable("arl");

                entity.Property(e => e.Idarl).HasColumnName("idarl");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Habilitado)
                    .HasColumnName("habilitado")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Usuariocreacion)
                    .HasMaxLength(20)
                    .HasColumnName("usuariocreacion");

                entity.Property(e => e.Valor)
                    .HasPrecision(6)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.Idcargo)
                    .HasName("cargos_pkey");

                entity.ToTable("cargos");

                entity.Property(e => e.Idcargo).HasColumnName("idcargo");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuariocreacion)
                    .HasMaxLength(20)
                    .HasColumnName("usuariocreacion");
            });

            modelBuilder.Entity<Contratoslaborale>(entity =>
            {
                entity.HasKey(e => e.Idcontrato)
                    .HasName("contratoslaborales_pkey");

                entity.ToTable("contratoslaborales");

                entity.Property(e => e.Idcontrato).HasColumnName("idcontrato");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Fechafin)
                    .HasColumnType("date")
                    .HasColumnName("fechafin");

                entity.Property(e => e.Fechainicio)
                    .HasColumnType("date")
                    .HasColumnName("fechainicio");

                entity.Property(e => e.Idarl).HasColumnName("idarl");

                entity.Property(e => e.Idcargo).HasColumnName("idcargo");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Idtipodocumento).HasColumnName("idtipodocumento");

                entity.Property(e => e.Numerodocumento)
                    .HasPrecision(16)
                    .HasColumnName("numerodocumento");

                entity.Property(e => e.Primerapellido)
                    .HasMaxLength(20)
                    .HasColumnName("primerapellido");

                entity.Property(e => e.Primernombre)
                    .HasMaxLength(20)
                    .HasColumnName("primernombre");

                entity.Property(e => e.Salario)
                    .HasPrecision(12)
                    .HasColumnName("salario");

                entity.Property(e => e.Segundoapellido)
                    .HasMaxLength(20)
                    .HasColumnName("segundoapellido");

                entity.Property(e => e.Segundonombre)
                    .HasMaxLength(20)
                    .HasColumnName("segundonombre");

                entity.Property(e => e.Usuariocreacion)
                    .HasMaxLength(20)
                    .HasColumnName("usuariocreacion");

                entity.HasOne(d => d.IdarlNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idarl)
                    .HasConstraintName("contratoslaborales_fk1");

                entity.HasOne(d => d.IdcargoNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idcargo)
                    .HasConstraintName("contratoslaborales_fk2");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idestado)
                    .HasConstraintName("contratoslaborales_fk");

                entity.HasOne(d => d.IdtipodocumentoNavigation)
                    .WithMany(p => p.Contratoslaborales)
                    .HasForeignKey(d => d.Idtipodocumento)
                    .HasConstraintName("contratoslaborales_fk3");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Idestado)
                    .HasName("estados_pkey");

                entity.ToTable("estados");

                entity.Property(e => e.Idestado).HasColumnName("idestado");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuariocreacion)
                    .HasMaxLength(20)
                    .HasColumnName("usuariocreacion");
            });

            modelBuilder.Entity<Novedadesnomina>(entity =>
            {
                entity.HasKey(e => e.Idnovedadnomina)
                    .HasName("novedadesnomina_pkey");

                entity.ToTable("novedadesnomina");

                entity.Property(e => e.Idnovedadnomina).HasColumnName("idnovedadnomina");

                entity.Property(e => e.Descuentos)
                    .HasPrecision(12)
                    .HasColumnName("descuentos");

                entity.Property(e => e.Fechacreacion).HasColumnName("fechacreacion");

                entity.Property(e => e.Horaextradiurna)
                    .HasPrecision(12)
                    .HasColumnName("horaextradiurna");

                entity.Property(e => e.Horaextradominical)
                    .HasPrecision(12)
                    .HasColumnName("horaextradominical");

                entity.Property(e => e.Horaextrafestiva)
                    .HasPrecision(12)
                    .HasColumnName("horaextrafestiva");

                entity.Property(e => e.Horaextranocturna)
                    .HasPrecision(12)
                    .HasColumnName("horaextranocturna");

                entity.Property(e => e.Horaslaboradas)
                    .HasPrecision(4)
                    .HasColumnName("horaslaboradas");

                entity.Property(e => e.Idcontrato).HasColumnName("idcontrato");

                entity.Property(e => e.Periodolaborado)
                    .HasMaxLength(20)
                    .HasColumnName("periodolaborado");

                entity.Property(e => e.Usuariocreacion)
                    .HasMaxLength(20)
                    .HasColumnName("usuariocreacion");

                entity.HasOne(d => d.IdcontratoNavigation)
                    .WithMany(p => p.Novedadesnominas)
                    .HasForeignKey(d => d.Idcontrato)
                    .HasConstraintName("novedadesnomina_fk");
            });

            modelBuilder.Entity<Tipodocumento>(entity =>
            {
                entity.HasKey(e => e.Idtipodocumento)
                    .HasName("tipodocumento_pkey");

                entity.ToTable("tipodocumento");

                entity.Property(e => e.Idtipodocumento).HasColumnName("idtipodocumento");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuariocreacion)
                    .HasMaxLength(20)
                    .HasColumnName("usuariocreacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
