using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class user3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpleadoId",
                table: "AspNetUsers",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Empleado_EmpleadoId",
                table: "AspNetUsers",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Empleado_EmpleadoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmpleadoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "AspNetUsers");
        }
    }
}
