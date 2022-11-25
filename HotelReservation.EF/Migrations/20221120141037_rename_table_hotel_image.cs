using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.EF.Migrations
{
    public partial class rename_table_hotel_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Hotel_HotelId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "HotelImages");

            migrationBuilder.RenameIndex(
                name: "IX_Images_HotelId",
                table: "HotelImages",
                newName: "IX_HotelImages_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImages_Hotel_HotelId",
                table: "HotelImages",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImages_Hotel_HotelId",
                table: "HotelImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelImages",
                table: "HotelImages");

            migrationBuilder.RenameTable(
                name: "HotelImages",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_HotelImages_HotelId",
                table: "Images",
                newName: "IX_Images_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Hotel_HotelId",
                table: "Images",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
