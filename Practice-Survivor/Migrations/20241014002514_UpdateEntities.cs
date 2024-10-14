using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice_Survivor.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_Categories_CategoryEntityId",
                table: "Competitors");

            migrationBuilder.DropIndex(
                name: "IX_Competitors_CategoryEntityId",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "Competitors");

            migrationBuilder.DropColumn(
                name: "ModiifedDate",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryEntityId",
                table: "Competitors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModiifedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_CategoryEntityId",
                table: "Competitors",
                column: "CategoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_Categories_CategoryEntityId",
                table: "Competitors",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
