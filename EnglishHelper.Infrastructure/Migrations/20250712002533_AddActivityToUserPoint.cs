using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishHelper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityToUserPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "UserPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoiceEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    EvaluatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoiceEvaluations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPoints_ActivityId",
                table: "UserPoints",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_VoiceEvaluations_UserId",
                table: "VoiceEvaluations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPoints_Activity_ActivityId",
                table: "UserPoints",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPoints_Activity_ActivityId",
                table: "UserPoints");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "VoiceEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_UserPoints_ActivityId",
                table: "UserPoints");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "UserPoints");
        }
    }
}
