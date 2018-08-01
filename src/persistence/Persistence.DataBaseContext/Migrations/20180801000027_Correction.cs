using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class Correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_UserId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_UserId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Empleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Empleado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UserId",
                table: "Empleado",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_UserId",
                table: "Empleado",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
