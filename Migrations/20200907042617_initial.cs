using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace e_descarte_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "pontodescarte",
                columns: new[] { "id", "fone", "latitude", "longitude", "nome" },
                values: new object[,]
                {
                    { 1, "(48) 3445-8811", -28.686900999999999, -49.384303000000003, "FAMCRI" },
                    { 2, "(48) 3431-3700", -28.681298000000002, -49.3748468, "Faculdades ESUCRI" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pontodescarte");
        }
    }
}
