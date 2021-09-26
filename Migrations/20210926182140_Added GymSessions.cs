using Microsoft.EntityFrameworkCore.Migrations;

namespace excercise_api.Migrations
{
    public partial class AddedGymSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Excercices_excerciceId",
                table: "Sets");

            migrationBuilder.RenameColumn(
                name: "reps",
                table: "Sets",
                newName: "Reps");

            migrationBuilder.RenameColumn(
                name: "excerciceId",
                table: "Sets",
                newName: "ExcerciceId");

            migrationBuilder.RenameIndex(
                name: "IX_Sets_excerciceId",
                table: "Sets",
                newName: "IX_Sets_ExcerciceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Excercices_ExcerciceId",
                table: "Sets",
                column: "ExcerciceId",
                principalTable: "Excercices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Excercices_ExcerciceId",
                table: "Sets");

            migrationBuilder.RenameColumn(
                name: "Reps",
                table: "Sets",
                newName: "reps");

            migrationBuilder.RenameColumn(
                name: "ExcerciceId",
                table: "Sets",
                newName: "excerciceId");

            migrationBuilder.RenameIndex(
                name: "IX_Sets_ExcerciceId",
                table: "Sets",
                newName: "IX_Sets_excerciceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Excercices_excerciceId",
                table: "Sets",
                column: "excerciceId",
                principalTable: "Excercices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
