﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class a5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");
        }
    }
}
