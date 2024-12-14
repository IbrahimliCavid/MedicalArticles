using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LanguageIdColumnDeletedFromServiceAboutItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAboutItems_Languages_LanguageId",
                table: "ServiceAboutItems");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAboutItems_LanguageId",
                table: "ServiceAboutItems");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ServiceAboutItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ServiceAboutItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAboutItems_LanguageId",
                table: "ServiceAboutItems",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAboutItems_Languages_LanguageId",
                table: "ServiceAboutItems",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
