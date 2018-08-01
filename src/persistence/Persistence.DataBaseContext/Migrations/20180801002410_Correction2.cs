using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.DataBaseContext.Migrations
{
    public partial class Correction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
