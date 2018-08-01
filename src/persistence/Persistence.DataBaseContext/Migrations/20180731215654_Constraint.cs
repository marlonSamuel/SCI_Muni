using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class Constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Solicitud",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "DetalleSolicitud",
                newName: "Cantidad_Solicitada");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Solicitud",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Solicitud",
                table: "Solicitud",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Entrega",
                table: "Solicitud",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado_Solicitud",
                table: "Solicitud",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Solicitud",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Codigo_Programatico",
                table: "Solicitud",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Solicitud",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "No_Orden",
                table: "Solicitud",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "No_Serie",
                table: "Solicitud",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Solicitud",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unidad_Administrativa",
                table: "Solicitud",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Proveedor",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedor",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Proveedor",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedor",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Proveedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Proveedor",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Proveedor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Proveedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Proveedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nit",
                table: "Proveedor",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Proveedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Proveedor",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Producto",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Producto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Producto",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Producto",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Producto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Producto",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Producto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Producto",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Huella",
                table: "HuellaDactilar",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HuellaDactilar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "HuellaDactilar",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "HuellaDactilar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "HuellaDactilar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "HuellaDactilar",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "HuellaDactilar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "HuellaDactilar",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empleado",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Segundo_nombre",
                table: "Empleado",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Segundo_apellido",
                table: "Empleado",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Primer_nombre",
                table: "Empleado",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Primer_apellido",
                table: "Empleado",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Empleado",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Empleado",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empleado",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Empleado",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cantidad_Entregada",
                table: "DetalleSolicitud",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DetalleSolicitud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DetalleSolicitud",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "DetalleSolicitud",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DetalleSolicitud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "DetalleSolicitud",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DetalleSolicitud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DetalleSolicitud",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio_Compra",
                table: "DetalleCompra",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DetalleCompra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DetalleCompra",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "DetalleCompra",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DetalleCompra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "DetalleCompra",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DetalleCompra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DetalleCompra",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Departamento",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Departamento",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Departamento",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Compra",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Compra",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Compra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Compra",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Compra",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Compra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Compra",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "No_Serie",
                table: "Compra",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Compra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Compra",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CategoriaProducto",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "CategoriaProducto",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CategoriaProducto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CategoriaProducto",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CategoriaProducto",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CategoriaProducto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CategoriaProducto",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CategoriaProducto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CategoriaProducto",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CategoriaAlmacen",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "CategoriaAlmacen",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CategoriaAlmacen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CategoriaAlmacen",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CategoriaAlmacen",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CategoriaAlmacen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CategoriaAlmacen",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CategoriaAlmacen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CategoriaAlmacen",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cargo",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Cargo",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cargo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Cargo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Cargo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Cargo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Cargo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cargo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Cargo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Almacen",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Almacen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Almacen",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Almacen",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Almacen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Almacen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Almacen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Almacen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Almacen",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "Codigo_Programatico",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "No_Orden",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "No_Serie",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "Unidad_Administrativa",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Nit",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HuellaDactilar");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "HuellaDactilar");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "HuellaDactilar");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "HuellaDactilar");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "HuellaDactilar");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "Cantidad_Entregada",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DetalleCompra");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "No_Serie",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CategoriaAlmacen");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CategoriaAlmacen");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CategoriaAlmacen");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CategoriaAlmacen");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CategoriaAlmacen");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Almacen");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Solicitud",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Cantidad_Solicitada",
                table: "DetalleSolicitud",
                newName: "Cantidad");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Solicitud",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Entrega",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Estado_Solicitud",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Solicitud",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedor",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Producto",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Huella",
                table: "HuellaDactilar",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Segundo_nombre",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Segundo_apellido",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Primer_nombre",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Primer_apellido",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio_Compra",
                table: "DetalleCompra",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "CategoriaProducto",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "CategoriaAlmacen",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Cargo",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Almacen",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1);
        }
    }
}
