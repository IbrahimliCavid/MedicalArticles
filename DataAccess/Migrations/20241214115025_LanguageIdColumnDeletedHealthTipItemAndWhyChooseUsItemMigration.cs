using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LanguageIdColumnDeletedHealthTipItemAndWhyChooseUsItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthTipItems_Languages_LanguageId",
                table: "HealthTipItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WhyChooseUseItems_Languages_LanguageId",
                table: "WhyChooseUseItems");

            migrationBuilder.DropIndex(
                name: "IX_WhyChooseUseItems_LanguageId",
                table: "WhyChooseUseItems");

            migrationBuilder.DropIndex(
                name: "IX_HealthTipItems_LanguageId",
                table: "HealthTipItems");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "WhyChooseUseItems");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "HealthTipItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "WhyChooseUseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "HealthTipItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WhyChooseUseItems_LanguageId",
                table: "WhyChooseUseItems",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthTipItems_LanguageId",
                table: "HealthTipItems",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthTipItems_Languages_LanguageId",
                table: "HealthTipItems",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WhyChooseUseItems_Languages_LanguageId",
                table: "WhyChooseUseItems",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
