using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class nh1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batiments",
                columns: table => new
                {
                    BatimentId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Adresse = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.BatimentId);
                });

            migrationBuilder.CreateTable(
                name: "Cadrans",
                columns: table => new
                {
                    CadranId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CadranModel = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    NombreRoues = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrixWatt = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    HeureActivation = table.Column<string>(type: "NVARCHAR2(48)", nullable: false),
                    HeureArret = table.Column<string>(type: "NVARCHAR2(48)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadrans", x => x.CadranId);
                });

            migrationBuilder.CreateTable(
                name: "Compteurs",
                columns: table => new
                {
                    CompteurId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Marque = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Modele = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AnneeCreation = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VoltageMax = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compteurs", x => x.CompteurId);
                });

            migrationBuilder.CreateTable(
                name: "Operateurs",
                columns: table => new
                {
                    OperateurId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DateEmbauche = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Civilite = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CIN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nom = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Prenom = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operateurs", x => x.OperateurId);
                });

            migrationBuilder.CreateTable(
                name: "ReleveCadrans",
                columns: table => new
                {
                    ReleveCadranId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IndexRoues = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InstanceCadranId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrixWatt = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleveCadrans", x => x.ReleveCadranId);
                });

            migrationBuilder.CreateTable(
                name: "InstanceCompteurs",
                columns: table => new
                {
                    InstanceCompteurId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CompteurId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BatimentId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DateInstallation = table.Column<string>(type: "NVARCHAR2(10)", nullable: false)
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
                    InstanceCadranId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InstanceCompteurId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CadranId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IndexRoues = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                name: "Releve",
                columns: table => new
                {
                    ReleveId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DateReleve = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    InstanceCompteurId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BatimentId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OperateurId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releve", x => x.ReleveId);
                    table.ForeignKey(
                        name: "FK_Releve_InstanceCompteurs_InstanceCompteurId",
                        column: x => x.InstanceCompteurId,
                        principalTable: "InstanceCompteurs",
                        principalColumn: "InstanceCompteurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Releve_Operateurs_OperateurId",
                        column: x => x.OperateurId,
                        principalTable: "Operateurs",
                        principalColumn: "OperateurId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Releve_InstanceCompteurId",
                table: "Releve",
                column: "InstanceCompteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Releve_OperateurId",
                table: "Releve",
                column: "OperateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstanceCadrans");

            migrationBuilder.DropTable(
                name: "Releve");

            migrationBuilder.DropTable(
                name: "ReleveCadrans");

            migrationBuilder.DropTable(
                name: "Cadrans");

            migrationBuilder.DropTable(
                name: "InstanceCompteurs");

            migrationBuilder.DropTable(
                name: "Operateurs");

            migrationBuilder.DropTable(
                name: "Batiments");

            migrationBuilder.DropTable(
                name: "Compteurs");
        }
    }
}
