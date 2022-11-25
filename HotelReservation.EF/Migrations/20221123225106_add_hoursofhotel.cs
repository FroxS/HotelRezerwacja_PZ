using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.EF.Migrations
{
    public partial class add_hoursofhotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoursCheckInFrom",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoursCheckInTo",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoursCheckOutFrom",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoursCheckOutTo",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursCheckInFrom",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "HoursCheckInTo",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "HoursCheckOutFrom",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "HoursCheckOutTo",
                table: "Hotel");
        }
    }
}
