using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class UpdateRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Almacen_CategoriaAlmacen_CategoriaAlmacenId",
                table: "Almacen");

            migrationBuilder.DropIndex(
                name: "IX_Almacen_CategoriaAlmacenId",
                table: "Almacen");

            migrationBuilder.DropColumn(
                name: "CategoriaAlmacenId",
                table: "Almacen");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaAlmacenId",
                table: "CategoriaProducto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProducto_CategoriaAlmacenId",
                table: "CategoriaProducto",
                column: "CategoriaAlmacenId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaProducto_CategoriaAlmacen_CategoriaAlmacenId",
                table: "CategoriaProducto",
                column: "CategoriaAlmacenId",
                principalTable: "CategoriaAlmacen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaProducto_CategoriaAlmacen_CategoriaAlmacenId",
                table: "CategoriaProducto");

            migrationBuilder.DropIndex(
                name: "IX_CategoriaProducto_CategoriaAlmacenId",
                table: "CategoriaProducto");

            migrationBuilder.DropColumn(
                name: "CategoriaAlmacenId",
                table: "CategoriaProducto");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaAlmacenId",
                table: "Almacen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Almacen_CategoriaAlmacenId",
                table: "Almacen",
                column: "CategoriaAlmacenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Almacen_CategoriaAlmacen_CategoriaAlmacenId",
                table: "Almacen",
                column: "CategoriaAlmacenId",
                principalTable: "CategoriaAlmacen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
