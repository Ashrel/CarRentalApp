using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalApp.Data.Migrations
{
    public partial class AddedMakeModelRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LicensePlateNumber",
                table: "Cars",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModels",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "CarModels");

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlateNumber",
                table: "Cars",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
