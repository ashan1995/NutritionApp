using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessAppData.Migrations
{
    public partial class Entitycreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FitnessPackageId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NutritionPackageId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FitnessPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessPackages", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "NutritionPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromotionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    BMI = table.Column<float>(type: "real", nullable: false),
                    BodyFat = table.Column<float>(type: "real", nullable: false),
                    WakeupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SleepTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentWorkoutPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutDietTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FitnessTyoeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessSchedules_FitnessTyoes_FitnessTyoeId",
                        column: x => x.FitnessTyoeId,
                        principalTable: "FitnessTyoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FitnessSchedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FitnessPackageId",
                table: "Users",
                column: "FitnessPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NutritionPackageId",
                table: "Users",
                column: "NutritionPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessSchedules_FitnessTyoeId",
                table: "FitnessSchedules",
                column: "FitnessTyoeId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessSchedules_UserId",
                table: "FitnessSchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FitnessPackages_FitnessPackageId",
                table: "Users",
                column: "FitnessPackageId",
                principalTable: "FitnessPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_NutritionPackages_NutritionPackageId",
                table: "Users",
                column: "NutritionPackageId",
                principalTable: "NutritionPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FitnessPackages_FitnessPackageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_NutritionPackages_NutritionPackageId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FitnessPackages");

            migrationBuilder.DropTable(
                name: "FitnessSchedules");

            migrationBuilder.DropTable(
                name: "NutritionPackages");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "FitnessTyoes");

            migrationBuilder.DropIndex(
                name: "IX_Users_FitnessPackageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NutritionPackageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FitnessPackageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NutritionPackageId",
                table: "Users");
        }
    }
}
