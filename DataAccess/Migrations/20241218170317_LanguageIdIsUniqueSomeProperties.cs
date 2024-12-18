using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LanguageIdIsUniqueSomeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WhyChooseUses_LanguageId",
                table: "WhyChooseUses");

            migrationBuilder.DropIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAbouts_LanguageId",
                table: "ServiceAbouts");

            migrationBuilder.DropIndex(
                name: "IX_HealthTips_LanguageId",
                table: "HealthTips");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_LanguageId",
                table: "Adresses");

            migrationBuilder.CreateIndex(
                name: "IX_WhyChooseUses_LanguageId",
                table: "WhyChooseUses",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAbouts_LanguageId",
                table: "ServiceAbouts",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthTips_LanguageId",
                table: "HealthTips",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_LanguageId",
                table: "Adresses",
                column: "LanguageId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WhyChooseUses_LanguageId",
                table: "WhyChooseUses");

            migrationBuilder.DropIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAbouts_LanguageId",
                table: "ServiceAbouts");

            migrationBuilder.DropIndex(
                name: "IX_HealthTips_LanguageId",
                table: "HealthTips");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_LanguageId",
                table: "Adresses");

            migrationBuilder.CreateIndex(
                name: "IX_WhyChooseUses_LanguageId",
                table: "WhyChooseUses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAbouts_LanguageId",
                table: "ServiceAbouts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthTips_LanguageId",
                table: "HealthTips",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_LanguageId",
                table: "Adresses",
                column: "LanguageId");
        }
    }
}
