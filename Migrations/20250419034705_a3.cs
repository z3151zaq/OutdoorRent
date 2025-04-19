using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class a3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Equipments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_TypeId",
                table: "Equipments",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentTypes_TypeId",
                table: "Equipments",
                column: "TypeId",
                principalTable: "EquipmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentTypes_TypeId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_TypeId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Equipments");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Equipments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
