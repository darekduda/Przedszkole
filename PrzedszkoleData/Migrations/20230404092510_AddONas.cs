using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzedszkoleData.Migrations
{
    /// <inheritdoc />
    public partial class AddONas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ONas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ONas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ONas");
        }
    }
}
