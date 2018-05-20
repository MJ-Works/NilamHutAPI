using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NilamHutAPI.Migrations
{
    public partial class AddedAdditionalNavigationPropertyPostProductUserTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_PostId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PostId",
                table: "Products",
                column: "PostId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_PostId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PostId",
                table: "Products",
                column: "PostId");
        }
    }
}
