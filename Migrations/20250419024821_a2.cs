using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class a2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCategoryEquipmentType",
                columns: table => new
                {
                    EquipmentCategorysId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentTypesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategoryEquipmentType", x => new { x.EquipmentCategorysId, x.EquipmentTypesId });
                    table.ForeignKey(
                        name: "FK_EquipmentCategoryEquipmentType_EquipmentCategories_EquipmentCategorysId",
                        column: x => x.EquipmentCategorysId,
                        principalTable: "EquipmentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentCategoryEquipmentType_EquipmentTypes_EquipmentTypesId",
                        column: x => x.EquipmentTypesId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCategoryEquipmentType_EquipmentTypesId",
                table: "EquipmentCategoryEquipmentType",
                column: "EquipmentTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentCategoryEquipmentType");

            migrationBuilder.DropTable(
                name: "EquipmentCategories");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");
        }
    }
}
