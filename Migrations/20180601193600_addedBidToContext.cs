using Microsoft.EntityFrameworkCore.Migrations;

namespace NilamHutAPI.Migrations
{
    public partial class addedBidToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_ApplicationUserId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_ApplicationUserId",
                table: "User",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_ApplicationUserId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_ApplicationUserId",
                table: "User",
                column: "ApplicationUserId");
        }
    }
}
