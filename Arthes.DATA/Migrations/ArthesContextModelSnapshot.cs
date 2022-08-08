﻿// <auto-generated />
using Arthes.DATA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arthes.DATA.Migrations
{
    [DbContext(typeof(ArthesContext))]
    partial class ArthesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Arthes.DATA.Models.Fabricante", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Linha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodLinha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoLinhaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.HasIndex("TipoLinhaId");

                    b.ToTable("Linha");
                });

            modelBuilder.Entity("Arthes.DATA.Models.LinhaReceita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LinhaId")
                        .HasColumnType("int");

                    b.Property<int>("ReceitaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId");

                    b.HasIndex("ReceitaId");

                    b.ToTable("LinhaReceita");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<int>("IdRevista")
                        .HasColumnType("int");

                    b.Property<int>("NivelDificuldade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdRevista");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Revista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnoEdicao")
                        .HasColumnType("int");

                    b.Property<int>("MesEdicao")
                        .HasColumnType("int");

                    b.Property<int>("NumEdicao")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Revista");
                });

            modelBuilder.Entity("Arthes.DATA.Models.TipoLinha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoLinha");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Linha", b =>
                {
                    b.HasOne("Arthes.DATA.Models.Fabricante", "Fabricante")
                        .WithMany("Linha")
                        .HasForeignKey("FabricanteId")
                        .IsRequired()
                        .HasConstraintName("FK_Linha_Fabricante");

                    b.HasOne("Arthes.DATA.Models.TipoLinha", "TipoLinha")
                        .WithMany("Linha")
                        .HasForeignKey("TipoLinhaId")
                        .IsRequired()
                        .HasConstraintName("FK_Linha_TipoLinha");

                    b.Navigation("Fabricante");

                    b.Navigation("TipoLinha");
                });

            modelBuilder.Entity("Arthes.DATA.Models.LinhaReceita", b =>
                {
                    b.HasOne("Arthes.DATA.Models.Linha", "Linha")
                        .WithMany("LinhaReceita")
                        .HasForeignKey("LinhaId")
                        .IsRequired()
                        .HasConstraintName("FK_LinhaReceita_Linha");

                    b.HasOne("Arthes.DATA.Models.Receita", "Receita")
                        .WithMany("LinhaReceita")
                        .HasForeignKey("ReceitaId")
                        .IsRequired()
                        .HasConstraintName("FK_LinhaReceita_Receita");

                    b.Navigation("Linha");

                    b.Navigation("Receita");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Receita", b =>
                {
                    b.HasOne("Arthes.DATA.Models.Revista", "IdRevistaNavigation")
                        .WithMany("Receita")
                        .HasForeignKey("IdRevista")
                        .IsRequired()
                        .HasConstraintName("FK_Receita_Revista");

                    b.Navigation("IdRevistaNavigation");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Fabricante", b =>
                {
                    b.Navigation("Linha");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Linha", b =>
                {
                    b.Navigation("LinhaReceita");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Receita", b =>
                {
                    b.Navigation("LinhaReceita");
                });

            modelBuilder.Entity("Arthes.DATA.Models.Revista", b =>
                {
                    b.Navigation("Receita");
                });

            modelBuilder.Entity("Arthes.DATA.Models.TipoLinha", b =>
                {
                    b.Navigation("Linha");
                });
#pragma warning restore 612, 618
        }
    }
}
