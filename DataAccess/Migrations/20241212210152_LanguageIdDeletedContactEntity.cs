using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LanguageIdDeletedContactEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Languages_LanguageId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Contacts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Languages_LanguageId",
                table: "Contacts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
