using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailTemplatesBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdditionalTrackingPropertiesToParagraph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Paragraphs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Paragraphs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Paragraphs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Paragraphs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Paragraphs");
        }
    }
}
