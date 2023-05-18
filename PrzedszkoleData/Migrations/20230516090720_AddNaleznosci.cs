using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzedszkoleData.Migrations
{
    /// <inheritdoc />
    public partial class AddNaleznosci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Naleznosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rok = table.Column<int>(type: "int", nullable: false),
                    Miesiac = table.Column<int>(type: "int", nullable: false),
                    Kwota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DzieckoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naleznosci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Naleznosci_Dziecko_DzieckoId",
                        column: x => x.DzieckoId,
                        principalTable: "Dziecko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Naleznosci_DzieckoId",
                table: "Naleznosci",
                column: "DzieckoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Naleznosci");
        }
    }
}
