using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class user2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Almacen_AspNetUsers_CreatedBy",
                table: "Almacen");

            migrationBuilder.DropForeignKey(
                name: "FK_Almacen_AspNetUsers_DeletedBy",
                table: "Almacen");

            migrationBuilder.DropForeignKey(
                name: "FK_Almacen_AspNetUsers_UpdatedBy",
                table: "Almacen");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_AspNetUsers_CreatedBy",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_AspNetUsers_DeletedBy",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_AspNetUsers_UpdatedBy",
                table: "Cargo");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaAlmacen_AspNetUsers_CreatedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaAlmacen_AspNetUsers_DeletedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaAlmacen_AspNetUsers_UpdatedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaProducto_AspNetUsers_CreatedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaProducto_AspNetUsers_DeletedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaProducto_AspNetUsers_UpdatedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_CreatedBy",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_DeletedBy",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_UpdatedBy",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_AspNetUsers_CreatedBy",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_AspNetUsers_DeletedBy",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_AspNetUsers_UpdatedBy",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_AspNetUsers_CreatedBy",
                table: "DetalleCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_AspNetUsers_DeletedBy",
                table: "DetalleCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleCompra_AspNetUsers_UpdatedBy",
                table: "DetalleCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleSolicitud_AspNetUsers_CreatedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleSolicitud_AspNetUsers_DeletedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleSolicitud_AspNetUsers_UpdatedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_CreatedBy",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_DeletedBy",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_UpdatedBy",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_HuellaDactilar_AspNetUsers_CreatedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropForeignKey(
                name: "FK_HuellaDactilar_AspNetUsers_DeletedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropForeignKey(
                name: "FK_HuellaDactilar_AspNetUsers_UpdatedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_AspNetUsers_CreatedBy",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_AspNetUsers_DeletedBy",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_AspNetUsers_UpdatedBy",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_AspNetUsers_CreatedBy",
                table: "Proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_AspNetUsers_DeletedBy",
                table: "Proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_AspNetUsers_UpdatedBy",
                table: "Proveedor");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_AspNetUsers_CreatedBy",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_AspNetUsers_DeletedBy",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitud_AspNetUsers_UpdatedBy",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_CreatedBy",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_DeletedBy",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_UpdatedBy",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_CreatedBy",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_DeletedBy",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_UpdatedBy",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Producto_CreatedBy",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_DeletedBy",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_UpdatedBy",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_HuellaDactilar_CreatedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropIndex(
                name: "IX_HuellaDactilar_DeletedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropIndex(
                name: "IX_HuellaDactilar_UpdatedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_CreatedBy",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_DeletedBy",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_UpdatedBy",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_DetalleSolicitud_CreatedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropIndex(
                name: "IX_DetalleSolicitud_DeletedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropIndex(
                name: "IX_DetalleSolicitud_UpdatedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompra_CreatedBy",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompra_DeletedBy",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_DetalleCompra_UpdatedBy",
                table: "DetalleCompra");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_CreatedBy",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_DeletedBy",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_UpdatedBy",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Compra_CreatedBy",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_DeletedBy",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_UpdatedBy",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaProducto_CreatedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaProducto_DeletedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaProducto_UpdatedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaAlmacen_CreatedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaAlmacen_DeletedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaAlmacen_UpdatedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_CreatedBy",
                table: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_DeletedBy",
                table: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_UpdatedBy",
                table: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Almacen_CreatedBy",
                table: "Almacen");

            migrationBuilder.DropIndex(
                name: "IX_Almacen_DeletedBy",
                table: "Almacen");

            migrationBuilder.DropIndex(
                name: "IX_Almacen_UpdatedBy",
                table: "Almacen");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "HuellaDactilar",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "HuellaDactilar",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HuellaDactilar",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DetalleSolicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "DetalleSolicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DetalleSolicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DetalleCompra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "DetalleCompra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DetalleCompra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Almacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Almacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Almacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "HuellaDactilar",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "HuellaDactilar",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HuellaDactilar",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DetalleSolicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "DetalleSolicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DetalleSolicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DetalleCompra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "DetalleCompra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DetalleCompra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Almacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Almacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Almacen",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_CreatedBy",
                table: "Solicitud",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_DeletedBy",
                table: "Solicitud",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_UpdatedBy",
                table: "Solicitud",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_CreatedBy",
                table: "Proveedor",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_DeletedBy",
                table: "Proveedor",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_UpdatedBy",
                table: "Proveedor",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CreatedBy",
                table: "Producto",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_DeletedBy",
                table: "Producto",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_UpdatedBy",
                table: "Producto",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HuellaDactilar_CreatedBy",
                table: "HuellaDactilar",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HuellaDactilar_DeletedBy",
                table: "HuellaDactilar",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HuellaDactilar_UpdatedBy",
                table: "HuellaDactilar",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CreatedBy",
                table: "Empleado",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DeletedBy",
                table: "Empleado",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UpdatedBy",
                table: "Empleado",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitud_CreatedBy",
                table: "DetalleSolicitud",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitud_DeletedBy",
                table: "DetalleSolicitud",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitud_UpdatedBy",
                table: "DetalleSolicitud",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_CreatedBy",
                table: "DetalleCompra",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_DeletedBy",
                table: "DetalleCompra",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_UpdatedBy",
                table: "DetalleCompra",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_CreatedBy",
                table: "Departamento",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_DeletedBy",
                table: "Departamento",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_UpdatedBy",
                table: "Departamento",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CreatedBy",
                table: "Compra",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_DeletedBy",
                table: "Compra",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UpdatedBy",
                table: "Compra",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProducto_CreatedBy",
                table: "CategoriaProducto",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProducto_DeletedBy",
                table: "CategoriaProducto",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProducto_UpdatedBy",
                table: "CategoriaProducto",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaAlmacen_CreatedBy",
                table: "CategoriaAlmacen",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaAlmacen_DeletedBy",
                table: "CategoriaAlmacen",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaAlmacen_UpdatedBy",
                table: "CategoriaAlmacen",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_CreatedBy",
                table: "Cargo",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_DeletedBy",
                table: "Cargo",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_UpdatedBy",
                table: "Cargo",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Almacen_CreatedBy",
                table: "Almacen",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Almacen_DeletedBy",
                table: "Almacen",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Almacen_UpdatedBy",
                table: "Almacen",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Almacen_AspNetUsers_CreatedBy",
                table: "Almacen",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Almacen_AspNetUsers_DeletedBy",
                table: "Almacen",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Almacen_AspNetUsers_UpdatedBy",
                table: "Almacen",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_AspNetUsers_CreatedBy",
                table: "Cargo",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_AspNetUsers_DeletedBy",
                table: "Cargo",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_AspNetUsers_UpdatedBy",
                table: "Cargo",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaAlmacen_AspNetUsers_CreatedBy",
                table: "CategoriaAlmacen",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaAlmacen_AspNetUsers_DeletedBy",
                table: "CategoriaAlmacen",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaAlmacen_AspNetUsers_UpdatedBy",
                table: "CategoriaAlmacen",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaProducto_AspNetUsers_CreatedBy",
                table: "CategoriaProducto",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaProducto_AspNetUsers_DeletedBy",
                table: "CategoriaProducto",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaProducto_AspNetUsers_UpdatedBy",
                table: "CategoriaProducto",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_CreatedBy",
                table: "Compra",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_DeletedBy",
                table: "Compra",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_UpdatedBy",
                table: "Compra",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_AspNetUsers_CreatedBy",
                table: "Departamento",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_AspNetUsers_DeletedBy",
                table: "Departamento",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_AspNetUsers_UpdatedBy",
                table: "Departamento",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_AspNetUsers_CreatedBy",
                table: "DetalleCompra",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_AspNetUsers_DeletedBy",
                table: "DetalleCompra",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleCompra_AspNetUsers_UpdatedBy",
                table: "DetalleCompra",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleSolicitud_AspNetUsers_CreatedBy",
                table: "DetalleSolicitud",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleSolicitud_AspNetUsers_DeletedBy",
                table: "DetalleSolicitud",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleSolicitud_AspNetUsers_UpdatedBy",
                table: "DetalleSolicitud",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_CreatedBy",
                table: "Empleado",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_DeletedBy",
                table: "Empleado",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_UpdatedBy",
                table: "Empleado",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HuellaDactilar_AspNetUsers_CreatedBy",
                table: "HuellaDactilar",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HuellaDactilar_AspNetUsers_DeletedBy",
                table: "HuellaDactilar",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HuellaDactilar_AspNetUsers_UpdatedBy",
                table: "HuellaDactilar",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_AspNetUsers_CreatedBy",
                table: "Producto",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_AspNetUsers_DeletedBy",
                table: "Producto",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_AspNetUsers_UpdatedBy",
                table: "Producto",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_AspNetUsers_CreatedBy",
                table: "Proveedor",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_AspNetUsers_DeletedBy",
                table: "Proveedor",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_AspNetUsers_UpdatedBy",
                table: "Proveedor",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_AspNetUsers_CreatedBy",
                table: "Solicitud",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_AspNetUsers_DeletedBy",
                table: "Solicitud",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitud_AspNetUsers_UpdatedBy",
                table: "Solicitud",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
