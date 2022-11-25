using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.EF.Migrations
{
    public partial class Rename_table_Hotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotlel_HotelCategorys_CategoryId",
                table: "Hotlel");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotlel_Images_ImageId",
                table: "Hotlel");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hotlel_HotlelId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotlel",
                table: "Hotlel");

            migrationBuilder.RenameTable(
                name: "Hotlel",
                newName: "Hotel");

            migrationBuilder.RenameIndex(
                name: "IX_Hotlel_ImageId",
                table: "Hotel",
                newName: "IX_Hotel_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotlel_CategoryId",
                table: "Hotel",
                newName: "IX_Hotel_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_HotelCategorys_CategoryId",
                table: "Hotel",
                column: "CategoryId",
                principalTable: "HotelCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Images_ImageId",
                table: "Hotel",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hotel_HotlelId",
                table: "Room",
                column: "HotlelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_HotelCategorys_CategoryId",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Images_ImageId",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hotel_HotlelId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "Hotlel");

            migrationBuilder.RenameIndex(
                name: "IX_Hotel_ImageId",
                table: "Hotlel",
                newName: "IX_Hotlel_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotel_CategoryId",
                table: "Hotlel",
                newName: "IX_Hotlel_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotlel",
                table: "Hotlel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotlel_HotelCategorys_CategoryId",
                table: "Hotlel",
                column: "CategoryId",
                principalTable: "HotelCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotlel_Images_ImageId",
                table: "Hotlel",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hotlel_HotlelId",
                table: "Room",
                column: "HotlelId",
                principalTable: "Hotlel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
