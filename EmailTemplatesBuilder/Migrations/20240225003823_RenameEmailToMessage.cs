using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailTemplatesBuilder.Migrations
{
    /// <inheritdoc />
    public partial class RenameEmailToMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Emails_EmailId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Items_EmailId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmailId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_EmailId",
                table: "Items",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Emails_EmailId",
                table: "Items",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "Id");
        }
    }
}
