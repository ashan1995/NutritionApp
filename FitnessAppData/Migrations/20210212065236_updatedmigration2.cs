using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessAppData.Migrations
{
    public partial class updatedmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTyoeId",
                table: "FitnessSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessSchedules_Users_UserId",
                table: "FitnessSchedules");

            migrationBuilder.RenameColumn(
                name: "FitnessTyoeId",
                table: "FitnessSchedules",
                newName: "FitnessTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessSchedules_FitnessTyoeId",
                table: "FitnessSchedules",
                newName: "IX_FitnessSchedules_FitnessTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FitnessSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTypeId",
                table: "FitnessSchedules",
                column: "FitnessTypeId",
                principalTable: "FitnessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessSchedules_Users_UserId",
                table: "FitnessSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTypeId",
                table: "FitnessSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessSchedules_Users_UserId",
                table: "FitnessSchedules");

            migrationBuilder.RenameColumn(
                name: "FitnessTypeId",
                table: "FitnessSchedules",
                newName: "FitnessTyoeId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessSchedules_FitnessTypeId",
                table: "FitnessSchedules",
                newName: "IX_FitnessSchedules_FitnessTyoeId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FitnessSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessSchedules_FitnessTypes_FitnessTyoeId",
                table: "FitnessSchedules",
                column: "FitnessTyoeId",
                principalTable: "FitnessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessSchedules_Users_UserId",
                table: "FitnessSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
