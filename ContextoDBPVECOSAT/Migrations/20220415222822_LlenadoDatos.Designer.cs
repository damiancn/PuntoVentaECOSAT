﻿// <auto-generated />
using System;
using ContextoDBPVECOSAT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContextoDBPVECOSAT.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220415222822_LlenadoDatos")]
    partial class LlenadoDatos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Catalogo.RolUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RolUsuarios", "Catalogo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Cajero"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Supervisor"
                        });
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Catalogo.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RolUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolUsuarioId");

                    b.ToTable("Usuarios", "Catalogo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NombreUsuario = "Damián",
                            Password = "pventa1",
                            RolUsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            NombreUsuario = "David",
                            Password = "pventa2",
                            RolUsuarioId = 2
                        });
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Tienda.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos", "Tienda");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Abarrotes"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Ropa"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Dulceria"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Panaderia"
                        });
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Tienda.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Productos", "Tienda");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartamentoId = 1,
                            Descripcion = "Azucar",
                            Precio = 25.50m
                        },
                        new
                        {
                            Id = 2,
                            DepartamentoId = 1,
                            Descripcion = "Lata Atún",
                            Precio = 14.00m
                        },
                        new
                        {
                            Id = 3,
                            DepartamentoId = 2,
                            Descripcion = "Pantalon Hombre",
                            Precio = 299.00m
                        },
                        new
                        {
                            Id = 4,
                            DepartamentoId = 2,
                            Descripcion = "Pantalon Mujer",
                            Precio = 399.00m
                        },
                        new
                        {
                            Id = 5,
                            DepartamentoId = 3,
                            Descripcion = "Chocolate",
                            Precio = 20.00m
                        },
                        new
                        {
                            Id = 6,
                            DepartamentoId = 3,
                            Descripcion = "Chicle",
                            Precio = 5.00m
                        },
                        new
                        {
                            Id = 7,
                            DepartamentoId = 4,
                            Descripcion = "Dona Cholate",
                            Precio = 7.00m
                        },
                        new
                        {
                            Id = 8,
                            DepartamentoId = 4,
                            Descripcion = "Pan Blanco",
                            Precio = 5.50m
                        });
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Venta.SubVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Importe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("SubVentas", "Venta");
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Venta.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadProductos")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ImporteTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ventas", "Venta");
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Catalogo.Usuario", b =>
                {
                    b.HasOne("ContextoDBPVECOSAT.Model.Catalogo.RolUsuario", "RolUsuario")
                        .WithMany()
                        .HasForeignKey("RolUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RolUsuario");
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Tienda.Producto", b =>
                {
                    b.HasOne("ContextoDBPVECOSAT.Model.Tienda.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Venta.SubVenta", b =>
                {
                    b.HasOne("ContextoDBPVECOSAT.Model.Tienda.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContextoDBPVECOSAT.Model.Venta.Venta", "Venta")
                        .WithMany("SubVentas")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Venta.Venta", b =>
                {
                    b.HasOne("ContextoDBPVECOSAT.Model.Catalogo.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ContextoDBPVECOSAT.Model.Venta.Venta", b =>
                {
                    b.Navigation("SubVentas");
                });
#pragma warning restore 612, 618
        }
    }
}
