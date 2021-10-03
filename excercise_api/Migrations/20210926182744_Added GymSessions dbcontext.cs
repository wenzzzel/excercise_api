using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace excercise_api.Migrations
{
    public partial class AddedGymSessionsdbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymSessionId",
                table: "Sets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GymSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymSessions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sets_GymSessionId",
                table: "Sets",
                column: "GymSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_GymSessions_GymSessionId",
                table: "Sets",
                column: "GymSessionId",
                principalTable: "GymSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_GymSessions_GymSessionId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "GymSessions");

            migrationBuilder.DropIndex(
                name: "IX_Sets_GymSessionId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "GymSessionId",
                table: "Sets");
        }
    }
}
