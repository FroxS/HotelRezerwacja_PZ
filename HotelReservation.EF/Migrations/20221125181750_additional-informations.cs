using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.EF.Migrations
{
    public partial class additionalinformations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Guest");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Room",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
