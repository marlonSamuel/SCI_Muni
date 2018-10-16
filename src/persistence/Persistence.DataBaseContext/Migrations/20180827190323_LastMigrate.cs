using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class LastMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "DetalleSolicitud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadMedida",
                table: "DetalleSolicitud",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "DetalleSolicitud");

            migrationBuilder.DropColumn(
                name: "UnidadMedida",
                table: "DetalleSolicitud");

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
        }
    }
}
