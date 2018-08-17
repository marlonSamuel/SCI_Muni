﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Persistence.DataBaseContext;
using System;

namespace Persistence.DataBaseContext.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180811210333_user2")]
    partial class user2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Model.Domain.Almacen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaAlmacenId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("ProductoId");

                    b.Property<int>("Stock");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaAlmacenId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Almacen");
                });

            modelBuilder.Entity("Model.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Foto")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Model.Domain.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("Model.Domain.CategoriaAlmacen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("CategoriaAlmacen");
                });

            modelBuilder.Entity("Model.Domain.CategoriaProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProducto");
                });

            modelBuilder.Entity("Model.Domain.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<DateTime?>("Fecha")
                        .IsRequired();

                    b.Property<int>("No_Serie");

                    b.Property<int>("ProveedorId");

                    b.Property<decimal>("Total_Compra");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Model.Domain.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("Model.Domain.DetalleCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cantidad");

                    b.Property<int>("CompraId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<decimal?>("Precio_Compra")
                        .IsRequired();

                    b.Property<int>("ProductoId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleCompra");
                });

            modelBuilder.Entity("Model.Domain.DetalleSolicitud", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cantidad_Entregada");

                    b.Property<int>("Cantidad_Solicitada");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("ProductoId");

                    b.Property<int>("SolicitudId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("SolicitudId");

                    b.ToTable("DetalleSolicitud");
                });

            modelBuilder.Entity("Model.Domain.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CargoId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("Foto")
                        .HasMaxLength(25);

                    b.Property<string>("Primer_apellido")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Primer_nombre")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Segundo_apellido")
                        .HasMaxLength(25);

                    b.Property<string>("Segundo_nombre")
                        .HasMaxLength(25);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("Model.Domain.HuellaDactilar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("EmpleadoId");

                    b.Property<byte[]>("Huella")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("HuellaDactilar");
                });

            modelBuilder.Entity("Model.Domain.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriaId");

                    b.Property<int?>("CategoriaProductoId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("Descripcion")
                        .HasMaxLength(500);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<decimal>("Precio");

                    b.Property<int>("Stock_Maximo");

                    b.Property<int>("Stock_Minimo");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProductoId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Model.Domain.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Nit")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("Model.Domain.Solicitud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Codigo");

                    b.Property<int>("Codigo_Programatico");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("EmpleadoId");

                    b.Property<string>("Estado_Solicitud")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<DateTime>("Fecha_Entrega");

                    b.Property<DateTime>("Fecha_Solicitud");

                    b.Property<int>("No_Orden");

                    b.Property<int>("No_Serie");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(500);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<decimal>("Total");

                    b.Property<string>("Unidad_Administrativa")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Solicitud");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Model.Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Model.Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Model.Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.Almacen", b =>
                {
                    b.HasOne("Model.Domain.CategoriaAlmacen", "CategoriaAlmacen")
                        .WithMany()
                        .HasForeignKey("CategoriaAlmacenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.Compra", b =>
                {
                    b.HasOne("Model.Domain.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.DetalleCompra", b =>
                {
                    b.HasOne("Model.Domain.Compra", "Compra")
                        .WithMany()
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.DetalleSolicitud", b =>
                {
                    b.HasOne("Model.Domain.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Solicitud", "Solicitud")
                        .WithMany()
                        .HasForeignKey("SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.Empleado", b =>
                {
                    b.HasOne("Model.Domain.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Domain.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.HuellaDactilar", b =>
                {
                    b.HasOne("Model.Domain.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Domain.Producto", b =>
                {
                    b.HasOne("Model.Domain.CategoriaProducto", "CategoriaProducto")
                        .WithMany()
                        .HasForeignKey("CategoriaProductoId");
                });

            modelBuilder.Entity("Model.Domain.Solicitud", b =>
                {
                    b.HasOne("Model.Domain.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
