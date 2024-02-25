using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailTemplatesBuilder.Migrations
{
    /// <inheritdoc />
    public partial class IncludeNavigationPropertyForContentDescriptor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Descriptors_ContentDescriptorId",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContentDescriptorId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Descriptors_ContentDescriptorId",
                table: "Items",
                column: "ContentDescriptorId",
                principalTable: "Descriptors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Descriptors_ContentDescriptorId",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContentDescriptorId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Descriptors_ContentDescriptorId",
                table: "Items",
                column: "ContentDescriptorId",
                principalTable: "Descriptors",
                principalColumn: "Id");
        }
    }
}
