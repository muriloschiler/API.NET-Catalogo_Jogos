﻿// <auto-generated />
using System;
using API.NET_Catalogo_Jogos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.NET_Catalogo_Jogos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.NET_Catalogo_Jogos.Entities.Categoria", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("API.NET_Catalogo_Jogos.Entities.Jogo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("anoLancamento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("id_categoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("produtora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.ToTable("jogos");
                });

            modelBuilder.Entity("API.NET_Catalogo_Jogos.Entities.Jogo", b =>
                {
                    b.HasOne("API.NET_Catalogo_Jogos.Entities.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
