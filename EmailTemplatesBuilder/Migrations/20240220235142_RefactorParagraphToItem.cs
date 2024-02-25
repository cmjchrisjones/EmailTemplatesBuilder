using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailTemplatesBuilder.Migrations
{
    /// <inheritdoc />
    public partial class RefactorParagraphToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_Descriptors_ContentTypeId",
                table: "Paragraphs");

            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_Emails_EmailId",
                table: "Paragraphs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paragraphs",
                table: "Paragraphs");

            migrationBuilder.RenameTable(
                name: "Paragraphs",
                newName: "Items");

            migrationBuilder.RenameColumn(
                name: "ContentTypeId",
                table: "Items",
                newName: "ContentDescriptorId");

            migrationBuilder.RenameIndex(
                name: "IX_Paragraphs_EmailId",
                table: "Items",
                newName: "IX_Items_EmailId");

            migrationBuilder.RenameIndex(
                name: "IX_Paragraphs_ContentTypeId",
                table: "Items",
                newName: "IX_Items_ContentDescriptorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Descriptors_ContentDescriptorId",
                table: "Items",
                column: "ContentDescriptorId",
                principalTable: "Descriptors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Emails_EmailId",
                table: "Items",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Descriptors_ContentDescriptorId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Emails_EmailId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Paragraphs");

            migrationBuilder.RenameColumn(
                name: "ContentDescriptorId",
                table: "Paragraphs",
                newName: "ContentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_EmailId",
                table: "Paragraphs",
                newName: "IX_Paragraphs_EmailId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ContentDescriptorId",
                table: "Paragraphs",
                newName: "IX_Paragraphs_ContentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paragraphs",
                table: "Paragraphs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_Descriptors_ContentTypeId",
                table: "Paragraphs",
                column: "ContentTypeId",
                principalTable: "Descriptors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_Emails_EmailId",
                table: "Paragraphs",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id");
        }
    }
}
