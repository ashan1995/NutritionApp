using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessAppData.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessSchedules_FitnessTyoes_FitnessTyoeId",
                table: "FitnessSchedules");

            migrationBuilder.DropTable(
                name: "FitnessTyoes");

            migrationBuilder.CreateTable(
                name: "FitnessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTypes", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "FitnessTypes");

            migrationBuilder.CreateTable(
                name: "FitnessTyoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTyoes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessSchedules_FitnessTyoes_FitnessTyoeId",
                table: "FitnessSchedules",
                column: "FitnessTyoeId",
                principalTable: "FitnessTyoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
