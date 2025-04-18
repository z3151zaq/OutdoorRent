using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class A1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Locations_Name",
                table: "Locations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name",
                table: "Locations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Location",
                table: "Equipments",
                column: "Location");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Locations_Location",
                table: "Equipments",
                column: "Location",
                principalTable: "Locations",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Locations_Location",
                table: "Equipments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Locations_Name",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Name",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_Location",
                table: "Equipments");
        }
    }
}
