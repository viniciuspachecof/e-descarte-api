using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace e_descarte_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    ponto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
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
                    latitude = table.Column<double>(nullable: false),
                    ativo = table.Column<bool>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    tipo = table.Column<int>(nullable: false),
                    cidadeId = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pontodescarte", x => x.id);
                    table.ForeignKey(
                        name: "FK_pontodescarte_cidade_cidadeId",
                        column: x => x.cidadeId,
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pontodescarte_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rankingpontuacao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pontuacao = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rankingpontuacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_rankingpontuacao_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pontodescarteitem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quant = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    totalponto = table.Column<int>(nullable: false),
                    pontodescarteId = table.Column<int>(nullable: false),
                    itemId = table.Column<int>(nullable: false),
                    usuarioId = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_pontodescarteitem_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cidade",
                columns: new[] { "id", "nome", "uf" },
                values: new object[,]
                {
                    { 1, "Joinville", "SC" },
                    { 2, "Florianópolis", "SC" },
                    { 3, "Blumenau", "SC" },
                    { 4, "São José", "SC" },
                    { 5, "Chapecó", "SC" },
                    { 6, "Itajaí", "SC" },
                    { 7, "Criciúma", "SC" },
                    { 8, "Jaraguá do Sul", "SC" },
                    { 9, "Palhoça", "SC" },
                    { 10, "Lages", "SC" }
                });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "id", "nome", "ponto" },
                values: new object[,]
                {
                    { 10, "Fogão", 10 },
                    { 9, "Geladeira", 9 },
                    { 8, "Aparelhos de Som", 8 },
                    { 7, "Câmeras Fotográficas", 7 },
                    { 6, "Impressoras", 6 },
                    { 2, "Televisores", 2 },
                    { 4, "Monitores", 4 },
                    { 3, "Tablets", 3 },
                    { 1, "Rádio", 1 },
                    { 5, "Teclados", 5 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "email", "nome", "senha", "tipo" },
                values: new object[,]
                {
                    { 2, "rodolfo@hotmail.com", "Rodolfo", "987654321", "DESCARTANTE" },
                    { 1, "vinicius@hotmail.com", "Vinicius", "123456789", "CATADOR" },
                    { 3, "admin@hotmail.com", "Administrador", "admin1234", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "pontodescarte",
                columns: new[] { "id", "ativo", "cidadeId", "fone", "latitude", "longitude", "nome", "status", "tipo", "usuarioId" },
                values: new object[,]
                {
                    { 1, true, 1, "(48) 3445-8811", -28.6868546, -49.384514699999997, "FAMCRI", false, 0, 1 },
                    { 2, true, 2, "(48) 3431-3700", -28.681176099999998, -49.3738259, "Faculdades ESUCRI", true, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "rankingpontuacao",
                columns: new[] { "id", "pontuacao", "usuarioId" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 2, 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pontodescarte_cidadeId",
                table: "pontodescarte",
                column: "cidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_pontodescarte_usuarioId",
                table: "pontodescarte",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_pontodescarteitem_itemId",
                table: "pontodescarteitem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_pontodescarteitem_pontodescarteId",
                table: "pontodescarteitem",
                column: "pontodescarteId");

            migrationBuilder.CreateIndex(
                name: "IX_pontodescarteitem_usuarioId",
                table: "pontodescarteitem",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_rankingpontuacao_usuarioId",
                table: "rankingpontuacao",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pontodescarteitem");

            migrationBuilder.DropTable(
                name: "rankingpontuacao");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "pontodescarte");

            migrationBuilder.DropTable(
                name: "cidade");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
