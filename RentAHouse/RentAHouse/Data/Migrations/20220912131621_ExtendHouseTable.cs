using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentAHouse.Data.Migrations
{
    public partial class ExtendHouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BathroomsCount",
                table: "Houses",
                newName: "RegionId");

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RentalPrice",
                table: "Houses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_MunicipalityId",
                table: "Houses",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RegionId",
                table: "Houses",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Municipalities_MunicipalityId",
                table: "Houses",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Regions_RegionId",
                table: "Houses",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Municipalities_MunicipalityId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Regions_RegionId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_MunicipalityId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_RegionId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "RentalPrice",
                table: "Houses");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Houses",
                newName: "BathroomsCount");
        }
    }
}
