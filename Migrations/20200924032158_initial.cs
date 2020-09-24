﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace e_descarte_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pontodescarte",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    fone = table.Column<string>(nullable: true),
                    longitude = table.Column<double>(nullable: false),
                    latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pontodescarte", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pontodescarteitem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quant = table.Column<int>(nullable: false),
                    pontodescarteId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pontodescarteitem", x => x.id);
                    table.ForeignKey(
                        name: "FK_pontodescarteitem_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pontodescarteitem_pontodescarte_pontodescarteId",
                        column: x => x.pontodescarteId,
                        principalTable: "pontodescarte",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "Rádio" },
                    { 2, "Televisão" }
                });

            migrationBuilder.InsertData(
                table: "pontodescarte",
                columns: new[] { "id", "fone", "latitude", "longitude", "nome" },
                values: new object[,]
                {
                    { 1, "(48) 3445-8811", -28.6868546, -49.384514699999997, "FAMCRI" },
                    { 2, "(48) 3431-3700", -28.681176099999998, -49.3738259, "Faculdades ESUCRI" }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "email", "nome", "senha" },
                values: new object[,]
                {
                    { 1, "vinicius.pachecof@hotmail.com", "Vinicius", "123" },
                    { 2, "rodolfo.casagrande@hotmail.com", "Rodolfo", "321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pontodescarteitem_itemId",
                table: "pontodescarteitem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_pontodescarteitem_pontodescarteId",
                table: "pontodescarteitem",
                column: "pontodescarteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pontodescarteitem");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "pontodescarte");
        }
    }
}
