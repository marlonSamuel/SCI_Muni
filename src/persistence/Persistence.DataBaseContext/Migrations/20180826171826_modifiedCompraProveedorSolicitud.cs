using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class modifiedCompraProveedorSolicitud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unidad_Medida",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unidades_Solicitadas",
                table: "Solicitud",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Unidades_entregadas",
                table: "Solicitud",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "No_Serie",
                table: "Compra",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Factura",
                table: "Compra",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidad_Medida",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "Unidades_Solicitadas",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "Unidades_entregadas",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "Factura",
                table: "Compra");

            migrationBuilder.AlterColumn<int>(
                name: "No_Serie",
                table: "Compra",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }
    }
}
