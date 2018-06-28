using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NilamHutAPI.Migrations
{
    public partial class SoldHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerID",
                table: "SoldHistories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "SoldHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "SoldHistories",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SoldHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoldHistories_UserId",
                table: "SoldHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldHistories_User_UserId",
                table: "SoldHistories",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldHistories_User_UserId",
                table: "SoldHistories");

            migrationBuilder.DropIndex(
                name: "IX_SoldHistories_UserId",
                table: "SoldHistories");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "SoldHistories");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "SoldHistories");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "SoldHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SoldHistories");
        }
    }
}
