using Microsoft.EntityFrameworkCore.Migrations;

namespace NilamHutAPI.Migrations
{
    public partial class UpdatedSoldHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductID",
                table: "SoldHistories",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "SoldHistories");
        }
    }
}
