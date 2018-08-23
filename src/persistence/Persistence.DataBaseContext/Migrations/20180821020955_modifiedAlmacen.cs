using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class modifiedAlmacen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Producto");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Almacen",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Almacen");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Producto",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
