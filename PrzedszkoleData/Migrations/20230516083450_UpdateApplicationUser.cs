using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzedszkoleData.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Dziecko",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dziecko_ApplicationUserId",
                table: "Dziecko",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dziecko_AspNetUsers_ApplicationUserId",
                table: "Dziecko",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dziecko_AspNetUsers_ApplicationUserId",
                table: "Dziecko");

            migrationBuilder.DropIndex(
                name: "IX_Dziecko_ApplicationUserId",
                table: "Dziecko");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Dziecko");
        }
    }
}
