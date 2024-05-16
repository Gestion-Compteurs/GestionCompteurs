using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cadrans_Compteurs_CompteurId",
                table: "Cadrans");

            migrationBuilder.DropIndex(
                name: "IX_Cadrans_CompteurId",
                table: "Cadrans");

            migrationBuilder.DropColumn(
                name: "CompteurId",
                table: "Cadrans");

            migrationBuilder.CreateTable(
                name: "CadranCompteur",
                columns: table => new
                {
                    CompteursLePossedantCompteurId = table.Column<int>(type: "int", nullable: false),
                    TypesCadransCadranId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadranCompteur", x => new { x.CompteursLePossedantCompteurId, x.TypesCadransCadranId });
                    table.ForeignKey(
                        name: "FK_CadranCompteur_Cadrans_TypesCadransCadranId",
                        column: x => x.TypesCadransCadranId,
                        principalTable: "Cadrans",
                        principalColumn: "CadranId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CadranCompteur_Compteurs_CompteursLePossedantCompteurId",
                        column: x => x.CompteursLePossedantCompteurId,
                        principalTable: "Compteurs",
                        principalColumn: "CompteurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadranCompteur_TypesCadransCadranId",
                table: "CadranCompteur",
                column: "TypesCadransCadranId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadranCompteur");

            migrationBuilder.AddColumn<int>(
                name: "CompteurId",
                table: "Cadrans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadrans_CompteurId",
                table: "Cadrans",
                column: "CompteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cadrans_Compteurs_CompteurId",
                table: "Cadrans",
                column: "CompteurId",
                principalTable: "Compteurs",
                principalColumn: "CompteurId");
        }
    }
}
