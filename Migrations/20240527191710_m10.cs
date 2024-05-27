using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegieId",
                table: "Operateurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "CompteActif",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegieId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Regies",
                columns: table => new
                {
                    RegieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailRegie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordRegie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomRegion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regies", x => x.RegieId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operateurs_RegieId",
                table: "Operateurs",
                column: "RegieId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegieId",
                table: "AspNetUsers",
                column: "RegieId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regies_RegieId",
                table: "AspNetUsers",
                column: "RegieId",
                principalTable: "Regies",
                principalColumn: "RegieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operateurs_Regies_RegieId",
                table: "Operateurs",
                column: "RegieId",
                principalTable: "Regies",
                principalColumn: "RegieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regies_RegieId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Operateurs_Regies_RegieId",
                table: "Operateurs");

            migrationBuilder.DropTable(
                name: "Regies");

            migrationBuilder.DropIndex(
                name: "IX_Operateurs_RegieId",
                table: "Operateurs");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegieId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegieId",
                table: "Operateurs");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompteActif",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegieId",
                table: "AspNetUsers");
        }
    }
}
