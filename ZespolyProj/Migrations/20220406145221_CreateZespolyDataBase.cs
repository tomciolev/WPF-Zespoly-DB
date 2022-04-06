using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZespolyProj.Migrations
{
    public partial class CreateZespolyDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zespoly",
                columns: table => new
                {
                    ZespolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiczbaCzlonkow = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zespoly", x => x.ZespolId);
                });

            migrationBuilder.CreateTable(
                name: "Czlonkowie",
                columns: table => new
                {
                    CzlonekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    DataUrodzenia = table.Column<DateTime>(nullable: false),
                    Pesel = table.Column<string>(nullable: true),
                    Plec = table.Column<int>(nullable: false),
                    DataZapisu = table.Column<DateTime>(nullable: false),
                    Funkcja = table.Column<string>(nullable: true),
                    ZespolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czlonkowie", x => x.CzlonekId);
                    table.ForeignKey(
                        name: "FK_Czlonkowie_Zespoly_ZespolId",
                        column: x => x.ZespolId,
                        principalTable: "Zespoly",
                        principalColumn: "ZespolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kierownik",
                columns: table => new
                {
                    KierownikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    DataUrodzenia = table.Column<DateTime>(nullable: false),
                    Pesel = table.Column<string>(nullable: true),
                    Plec = table.Column<int>(nullable: false),
                    Doswiadczenie = table.Column<int>(nullable: false),
                    ZespolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierownik", x => x.KierownikId);
                    table.ForeignKey(
                        name: "FK_Kierownik_Zespoly_ZespolId",
                        column: x => x.ZespolId,
                        principalTable: "Zespoly",
                        principalColumn: "ZespolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Czlonkowie_ZespolId",
                table: "Czlonkowie",
                column: "ZespolId");

            migrationBuilder.CreateIndex(
                name: "IX_Kierownik_ZespolId",
                table: "Kierownik",
                column: "ZespolId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Czlonkowie");

            migrationBuilder.DropTable(
                name: "Kierownik");

            migrationBuilder.DropTable(
                name: "Zespoly");
        }
    }
}
