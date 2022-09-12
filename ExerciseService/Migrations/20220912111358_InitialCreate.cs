using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExerciseService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LevelDetailsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalUserID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelDetails",
                columns: table => new
                {
                    LevelDetailsId = table.Column<int>(type: "integer", nullable: false),
                    Inhale = table.Column<int>(type: "integer", nullable: false),
                    Exhale = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelDetails", x => x.LevelDetailsId);
                    table.ForeignKey(
                        name: "FK_LevelDetails_Levels_LevelDetailsId",
                        column: x => x.LevelDetailsId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LevelId = table.Column<int>(type: "integer", nullable: false),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "LevelDetailsId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Beginner" },
                    { 2, 2, "Intermediate" },
                    { 3, 3, "Advanced" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ExternalUserID", "Name" },
                values: new object[,]
                {
                    { 1, 0, "John" },
                    { 2, 0, "Mary" },
                    { 3, 0, "Jane" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "IsFinished", "LevelId", "StartedAt", "UserId" },
                values: new object[,]
                {
                    { 1, false, 1, new DateTime(2022, 9, 12, 11, 13, 58, 784, DateTimeKind.Utc).AddTicks(2880), 1 },
                    { 2, false, 2, new DateTime(2022, 9, 12, 11, 13, 58, 784, DateTimeKind.Utc).AddTicks(2880), 1 },
                    { 3, false, 3, new DateTime(2022, 9, 12, 11, 13, 58, 784, DateTimeKind.Utc).AddTicks(2880), 2 }
                });

            migrationBuilder.InsertData(
                table: "LevelDetails",
                columns: new[] { "LevelDetailsId", "Duration", "Exhale", "Inhale" },
                values: new object[,]
                {
                    { 1, 10000, 1000, 1000 },
                    { 2, 20000, 2000, 2000 },
                    { 3, 30000, 3000, 3000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_LevelId",
                table: "Exercises",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "LevelDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
