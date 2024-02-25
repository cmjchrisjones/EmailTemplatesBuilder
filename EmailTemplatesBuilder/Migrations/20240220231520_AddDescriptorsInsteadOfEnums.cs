using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailTemplatesBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptorsInsteadOfEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Paragraphs");

            migrationBuilder.AddColumn<Guid>(
                name: "ContentTypeId",
                table: "Paragraphs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Descriptors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_ContentTypeId",
                table: "Paragraphs",
                column: "ContentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_Descriptors_ContentTypeId",
                table: "Paragraphs",
                column: "ContentTypeId",
                principalTable: "Descriptors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_Descriptors_ContentTypeId",
                table: "Paragraphs");

            migrationBuilder.DropTable(
                name: "Descriptors");

            migrationBuilder.DropIndex(
                name: "IX_Paragraphs_ContentTypeId",
                table: "Paragraphs");

            migrationBuilder.DropColumn(
                name: "ContentTypeId",
                table: "Paragraphs");

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                table: "Paragraphs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
