
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Arthes.DATA.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Arthes.DATA.Data
{
    public partial class ArthesContext : DbContext
    {
        public ArthesContext()
        {
        }

        public ArthesContext(DbContextOptions<ArthesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fabricante> Fabricante { get; set; }
        public virtual DbSet<Linha> Linha { get; set; }
        public virtual DbSet<LinhaReceita> LinhaReceita { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<Revista> Revista { get; set; }
        public virtual DbSet<TipoLinha> TipoLinha { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NO00108978;Initial Catalog=Arthes;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Linha>(entity =>
            {
                entity.HasOne(d => d.Fabricante)
                    .WithMany(p => p.Linha)
                    .HasForeignKey(d => d.FabricanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Linha_Fabricante");

                entity.HasOne(d => d.TipoLinha)
                    .WithMany(p => p.Linha)
                    .HasForeignKey(d => d.TipoLinhaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Linha_TipoLinha");
            });

            modelBuilder.Entity<LinhaReceita>(entity =>
            {
                entity.HasOne(d => d.Linha)
                    .WithMany(p => p.LinhaReceita)
                    .HasForeignKey(d => d.LinhaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LinhaReceita_Linha");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.LinhaReceita)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LinhaReceita_Receita");
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasOne(d => d.IdRevistaNavigation)
                    .WithMany(p => p.Receita)
                    .HasForeignKey(d => d.IdRevista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receita_Revista");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}