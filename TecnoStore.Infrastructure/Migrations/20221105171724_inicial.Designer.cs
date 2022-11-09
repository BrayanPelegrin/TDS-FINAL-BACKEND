﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TecnoStore.Infrastructure.Data;

#nullable disable

namespace TecnoStore.Infrastructure.Migrations
{
    [DbContext(typeof(TecnoStoreContext))]
    [Migration("20221105171724_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TecnoStore.Core.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreo")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsuarioCreo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Categorias", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Accesorios",
                            EstadoId = 1,
                            FechaCreo = new DateTime(2022, 11, 5, 13, 17, 24, 244, DateTimeKind.Local).AddTicks(3247),
                            UsuarioCreo = "Admin"
                        });
                });

            modelBuilder.Entity("TecnoStore.Core.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreo")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsuarioCreo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estado");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Activo",
                            FechaCreo = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Eliminado",
                            FechaCreo = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Agotado",
                            FechaCreo = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Descontinuado",
                            FechaCreo = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TecnoStore.Core.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCreo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Productos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 1,
                            Descripcion = "Longitud 25cm",
                            EstadoId = 1,
                            FechaCreo = new DateTime(2022, 11, 5, 13, 17, 24, 244, DateTimeKind.Local).AddTicks(6303),
                            Nombre = "Cable Tipo C",
                            Precio = 250m,
                            Stock = 25,
                            UsuarioCreo = "Admin"
                        });
                });

            modelBuilder.Entity("TecnoStore.Core.Entities.Categoria", b =>
                {
                    b.HasOne("TecnoStore.Core.Entities.Estado", "Estado")
                        .WithMany("Categorias")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("TecnoStore.Core.Entities.Producto", b =>
                {
                    b.HasOne("TecnoStore.Core.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Productos_Categorias_CategoriaId");

                    b.HasOne("TecnoStore.Core.Entities.Estado", "Estado")
                        .WithMany("Productos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("TecnoStore.Core.Entities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TecnoStore.Core.Entities.Estado", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}