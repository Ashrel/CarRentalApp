using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalApp.Data.Migrations
{
    public partial class LicensePlateNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlateNumber",
                table: "Cars",
                type: "nvarchar(8)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlateNumber",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Cars",
                type: "int",
                nullable: true);
        }
    }
}
