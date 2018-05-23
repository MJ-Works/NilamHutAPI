using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NilamHutAPI.Migrations
{
    public partial class UpdatedNavigationAndUpdatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_User_userId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldHistories_User_UserId",
                table: "SoldHistories");

            migrationBuilder.DropIndex(
                name: "IX_Rating_UserId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rating");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_userId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SoldHistories",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SoldHistories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Rating",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    BidPrice = table.Column<int>(nullable: false),
                    PostId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bid_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bid_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RatingId",
                table: "User",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldHistories_ApplicationUserId",
                table: "SoldHistories",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ApplicationUserId",
                table: "Rating",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CityId",
                table: "Posts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CountryId",
                table: "Posts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_ApplicationUserId",
                table: "Bid",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_PostId",
                table: "Bid",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_City_CityId",
                table: "Posts",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Country_CountryId",
                table: "Posts",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_User_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_ApplicationUserId",
                table: "Rating",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldHistories_AspNetUsers_ApplicationUserId",
                table: "SoldHistories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldHistories_User_UserId",
                table: "SoldHistories",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Rating_RatingId",
                table: "User",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_City_CityId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Country_CountryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_User_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_ApplicationUserId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldHistories_AspNetUsers_ApplicationUserId",
                table: "SoldHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldHistories_User_UserId",
                table: "SoldHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Rating_RatingId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropIndex(
                name: "IX_User_RatingId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_SoldHistories_ApplicationUserId",
                table: "SoldHistories");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ApplicationUserId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CountryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SoldHistories");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                newName: "IX_Posts_userId");

            migrationBuilder.AddColumn<int>(
                name: "UserRating",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SoldHistories",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Rating",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<Guid>(
                name: "userId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_User_userId",
                table: "Posts",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldHistories_User_UserId",
                table: "SoldHistories",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
