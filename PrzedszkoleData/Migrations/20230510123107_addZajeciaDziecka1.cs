using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzedszkoleData.Migrations
{
    /// <inheritdoc />
    public partial class addZajeciaDziecka1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZajeciaDziecka");

            migrationBuilder.CreateTable(
                name: "DzieckoZajeciaDodatkowe",
                columns: table => new
                {
                    DzieckoId = table.Column<int>(type: "int", nullable: false),
                    ZajeciaDodatkoweId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DzieckoZajeciaDodatkowe", x => new { x.DzieckoId, x.ZajeciaDodatkoweId });
                    table.ForeignKey(
                        name: "FK_DzieckoZajeciaDodatkowe_Dziecko_DzieckoId",
                        column: x => x.DzieckoId,
                        principalTable: "Dziecko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DzieckoZajeciaDodatkowe_ZajeciaDodatkowe_ZajeciaDodatkoweId",
                        column: x => x.ZajeciaDodatkoweId,
                        principalTable: "ZajeciaDodatkowe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DzieckoZajeciaDodatkowe_ZajeciaDodatkoweId",
                table: "DzieckoZajeciaDodatkowe",
                column: "ZajeciaDodatkoweId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DzieckoZajeciaDodatkowe");

            migrationBuilder.CreateTable(
                name: "ZajeciaDziecka",
                columns: table => new
                {
                    DzieckoId = table.Column<int>(type: "int", nullable: false),
                    ZajeciaDodatkoweId = table.Column<int>(type: "int", nullable: false),
                    RokIMiesiac = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZajeciaDziecka", x => new { x.DzieckoId, x.ZajeciaDodatkoweId });
                    table.ForeignKey(
                        name: "FK_ZajeciaDziecka_Dziecko_DzieckoId",
                        column: x => x.DzieckoId,
                        principalTable: "Dziecko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZajeciaDziecka_ZajeciaDodatkowe_ZajeciaDodatkoweId",
                        column: x => x.ZajeciaDodatkoweId,
                        principalTable: "ZajeciaDodatkowe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZajeciaDziecka_ZajeciaDodatkoweId",
                table: "ZajeciaDziecka",
                column: "ZajeciaDodatkoweId");
        }
    }
}
