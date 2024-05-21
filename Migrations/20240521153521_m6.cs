using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReleveId",
                table: "ReleveCadrans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReleveCadrans_ReleveId",
                table: "ReleveCadrans",
                column: "ReleveId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleveCadrans_Releves_ReleveId",
                table: "ReleveCadrans",
                column: "ReleveId",
                principalTable: "Releves",
                principalColumn: "ReleveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleveCadrans_Releves_ReleveId",
                table: "ReleveCadrans");

            migrationBuilder.DropIndex(
                name: "IX_ReleveCadrans_ReleveId",
                table: "ReleveCadrans");

            migrationBuilder.DropColumn(
                name: "ReleveId",
                table: "ReleveCadrans");
        }
    }
}
