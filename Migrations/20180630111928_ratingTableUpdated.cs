using Microsoft.EntityFrameworkCore.Migrations;

namespace NilamHutAPI.Migrations
{
    public partial class ratingTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GivenUserId",
                table: "Rating",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GivenUserId",
                table: "Rating");
        }
    }
}
