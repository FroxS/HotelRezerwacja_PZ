using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.EF.Migrations
{
    public partial class add_main_images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "RoomImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "RoomImages");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Images");
        }
    }
}
