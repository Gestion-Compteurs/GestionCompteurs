using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class cadrans2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstanceCompteurId",
                table: "InstanceCadrans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstanceCompteurId",
                table: "InstanceCadrans");
        }
    }
}
