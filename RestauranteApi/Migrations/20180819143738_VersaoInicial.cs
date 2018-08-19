using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestauranteApi.Migrations
{
    public partial class VersaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    SQRESTAURANTE = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NMRESTAURANTE = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKRESTAURANTE", x => x.SQRESTAURANTE);
                });

            migrationBuilder.CreateTable(
                name: "PRATO",
                columns: table => new
                {
                    SQPRATO = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NMPRATO = table.Column<string>(maxLength: 255, nullable: false),
                    SQRESTAURANTE = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PKPRATO", x => x.SQPRATO);
                    table.ForeignKey(
                        name: "FKRESTAURANTEPRATO",
                        column: x => x.SQRESTAURANTE,
                        principalTable: "Restaurante",
                        principalColumn: "SQRESTAURANTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRATO_SQRESTAURANTE",
                table: "PRATO",
                column: "SQRESTAURANTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRATO");

            migrationBuilder.DropTable(
                name: "Restaurante");
        }
    }
}
