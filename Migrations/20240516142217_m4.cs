using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadranCompteur");

            migrationBuilder.CreateTable(
                name: "CompteurCadrans",
                columns: table => new
                {
                    CompteurId = table.Column<int>(type: "int", nullable: false),
                    CadranId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteurCadrans", x => new { x.CadranId, x.CompteurId });
                    table.ForeignKey(
                        name: "FK_CompteurCadrans_Cadrans_CadranId",
                        column: x => x.CadranId,
                        principalTable: "Cadrans",
                        principalColumn: "CadranId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompteurCadrans_Compteurs_CompteurId",
                        column: x => x.CompteurId,
                        principalTable: "Compteurs",
                        principalColumn: "CompteurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompteurCadrans_CompteurId",
                table: "CompteurCadrans",
                column: "CompteurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompteurCadrans");

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
    }
}
