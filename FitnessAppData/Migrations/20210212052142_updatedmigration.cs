using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessAppData.Migrations
{
    public partial class updatedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTypeId",
                table: "FitnessSchedules");

            migrationBuilder.DropIndex(
                name: "IX_FitnessSchedules_FitnessTypeId",
                table: "FitnessSchedules");

            migrationBuilder.DropColumn(
                name: "FitnessTypeId",
                table: "FitnessSchedules");

            migrationBuilder.AddColumn<int>(
                name: "FitnessTyoeId",
                table: "FitnessSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessSchedules_FitnessTyoeId",
                table: "FitnessSchedules",
                column: "FitnessTyoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTyoeId",
                table: "FitnessSchedules",
                column: "FitnessTyoeId",
                principalTable: "FitnessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTyoeId",
                table: "FitnessSchedules");

            migrationBuilder.DropIndex(
                name: "IX_FitnessSchedules_FitnessTyoeId",
                table: "FitnessSchedules");

            migrationBuilder.DropColumn(
                name: "FitnessTyoeId",
                table: "FitnessSchedules");

            migrationBuilder.AddColumn<int>(
                name: "FitnessTypeId",
                table: "FitnessSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessSchedules_FitnessTypeId",
                table: "FitnessSchedules",
                column: "FitnessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTypeId",
                table: "FitnessSchedules",
                column: "FitnessTypeId",
                principalTable: "FitnessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
