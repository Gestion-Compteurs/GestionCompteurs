using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batiments",
                columns: table => new
                {
                    BatimentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.BatimentId);
                });

            migrationBuilder.CreateTable(
                name: "Compteurs",
                columns: table => new
                {
                    CompteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneeCreation = table.Column<int>(type: "int", nullable: false),
                    VoltageMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compteurs", x => x.CompteurId);
                });

            migrationBuilder.CreateTable(
                name: "ReleveCadrans",
                columns: table => new
                {
                    ReleveCadranId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexRoues = table.Column<int>(type: "int", nullable: false),
                    InstanceCadranId = table.Column<int>(type: "int", nullable: false),
                    PrixWatt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleveCadrans", x => x.ReleveCadranId);
                });

            migrationBuilder.CreateTable(
                name: "Cadrans",
                columns: table => new
                {
                    CadranId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadranModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreRoues = table.Column<int>(type: "int", nullable: false),
                    PrixWatt = table.Column<double>(type: "float", nullable: false),
                    HeureActivation = table.Column<TimeOnly>(type: "time", nullable: false),
                    HeureArret = table.Column<TimeOnly>(type: "time", nullable: false),
                    CompteurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadrans", x => x.CadranId);
                    table.ForeignKey(
                        name: "FK_Cadrans_Compteurs_CompteurId",
                        column: x => x.CompteurId,
                        principalTable: "Compteurs",
                        principalColumn: "CompteurId");
                });

            migrationBuilder.CreateTable(
                name: "InstanceCompteurs",
                columns: table => new
                {
                    InstanceCompteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompteurId = table.Column<int>(type: "int", nullable: false),
                    BatimentId = table.Column<int>(type: "int", nullable: false),
                    DateInstallation = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceCompteurs", x => x.InstanceCompteurId);
                    table.ForeignKey(
                        name: "FK_InstanceCompteurs_Batiments_BatimentId",
                        column: x => x.BatimentId,
                        principalTable: "Batiments",
                        principalColumn: "BatimentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstanceCompteurs_Compteurs_CompteurId",
                        column: x => x.CompteurId,
                        principalTable: "Compteurs",
                        principalColumn: "CompteurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstanceCadrans",
                columns: table => new
                {
                    InstanceCadranId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceCompteurId = table.Column<int>(type: "int", nullable: false),
                    CadranId = table.Column<int>(type: "int", nullable: false),
                    IndexRoues = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceCadrans", x => x.InstanceCadranId);
                    table.ForeignKey(
                        name: "FK_InstanceCadrans_Cadrans_CadranId",
                        column: x => x.CadranId,
                        principalTable: "Cadrans",
                        principalColumn: "CadranId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstanceCadrans_InstanceCompteurs_InstanceCompteurId",
                        column: x => x.InstanceCompteurId,
                        principalTable: "InstanceCompteurs",
                        principalColumn: "InstanceCompteurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Releves",
                columns: table => new
                {
                    ReleveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReleve = table.Column<DateOnly>(type: "date", nullable: false),
                    InstanceCompteurId = table.Column<int>(type: "int", nullable: false),
                    OperateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releves", x => x.ReleveId);
                    table.ForeignKey(
                        name: "FK_Releves_InstanceCompteurs_InstanceCompteurId",
                        column: x => x.InstanceCompteurId,
                        principalTable: "InstanceCompteurs",
                        principalColumn: "InstanceCompteurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadrans_CompteurId",
                table: "Cadrans",
                column: "CompteurId");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceCadrans_CadranId",
                table: "InstanceCadrans",
                column: "CadranId");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceCadrans_InstanceCompteurId",
                table: "InstanceCadrans",
                column: "InstanceCompteurId");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceCompteurs_BatimentId",
                table: "InstanceCompteurs",
                column: "BatimentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceCompteurs_CompteurId",
                table: "InstanceCompteurs",
                column: "CompteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Releves_InstanceCompteurId",
                table: "Releves",
                column: "InstanceCompteurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstanceCadrans");

            migrationBuilder.DropTable(
                name: "ReleveCadrans");

            migrationBuilder.DropTable(
                name: "Releves");

            migrationBuilder.DropTable(
                name: "Cadrans");

            migrationBuilder.DropTable(
                name: "InstanceCompteurs");

            migrationBuilder.DropTable(
                name: "Batiments");

            migrationBuilder.DropTable(
                name: "Compteurs");
        }
    }
}
