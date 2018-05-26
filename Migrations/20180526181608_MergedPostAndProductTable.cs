using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NilamHutAPI.Migrations
{
    public partial class MergedPostAndProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Posts_PostId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Posts_PostId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Products_PostId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Bid_PostId",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Bid");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Products",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Bid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CityId",
                table: "Products",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CountryId",
                table: "Products",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_ProductId",
                table: "Bid",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_City_CityId",
                table: "Products",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Country_CountryId",
                table: "Products",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Products_ProductId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_City_CityId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Country_CountryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CountryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Bid_ProductId",
                table: "Bid");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Bid");

        }
    }
}
