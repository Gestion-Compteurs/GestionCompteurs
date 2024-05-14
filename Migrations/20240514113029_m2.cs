using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReleveCadrans_InstanceCadranId",
                table: "ReleveCadrans",
                column: "InstanceCadranId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleveCadrans_InstanceCadrans_InstanceCadranId",
                table: "ReleveCadrans",
                column: "InstanceCadranId",
                principalTable: "InstanceCadrans",
                principalColumn: "InstanceCadranId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleveCadrans_InstanceCadrans_InstanceCadranId",
                table: "ReleveCadrans");

            migrationBuilder.DropIndex(
                name: "IX_ReleveCadrans_InstanceCadranId",
                table: "ReleveCadrans");
        }
    }
}
