using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class addEmpleadoIdAtUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Cargo_CargoId1",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_CargoId1",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "CargoId1",
                table: "Empleado");

            migrationBuilder.AlterColumn<int>(
                name: "CargoId",
                table: "Empleado",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargoId",
                table: "Empleado",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Cargo_CargoId",
                table: "Empleado",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Cargo_CargoId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_CargoId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CargoId",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CargoId1",
                table: "Empleado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargoId1",
                table: "Empleado",
                column: "CargoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Cargo_CargoId1",
                table: "Empleado",
                column: "CargoId1",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
