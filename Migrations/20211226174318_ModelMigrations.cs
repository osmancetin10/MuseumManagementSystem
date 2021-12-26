using Microsoft.EntityFrameworkCore.Migrations;

namespace MuseumManagementSystem.Migrations
{
    public partial class ModelMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muze",
                columns: table => new
                {
                    MuzeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MuzeAdi = table.Column<string>(nullable: false),
                    MuzeAdresi = table.Column<string>(nullable: false),
                    ZiyaretciSayisi = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muze", x => x.MuzeId);
                });

            migrationBuilder.CreateTable(
                name: "Eser",
                columns: table => new
                {
                    EserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EserAdi = table.Column<string>(nullable: false),
                    EserYili = table.Column<int>(nullable: false),
                    MuzeId = table.Column<int>(nullable: false),
                    Foto = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eser", x => x.EserId);
                    table.ForeignKey(
                        name: "FK_Muze_Eser_MuzeId",
                        column: x => x.MuzeId,
                        principalTable: "Muze",
                        principalColumn: "MuzeId",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Eser_MuzeId",
                table: "Eser",
                column: "MuzeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Muze");

            migrationBuilder.DropTable(
                name: "Eser");
        }
    }
}
