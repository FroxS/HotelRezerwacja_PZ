using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.EF.Migrations
{
    public partial class Add_many_images_to_hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Images_ImageId",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_ImageId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Hotel");

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Images_HotelId",
                table: "Images",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Hotel_HotelId",
                table: "Images",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Hotel_HotelId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_HotelId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Hotel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_ImageId",
                table: "Hotel",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Images_ImageId",
                table: "Hotel",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
