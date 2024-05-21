using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CIN",
                table: "Operateurs",
                newName: "Cin");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "NVARCHAR2(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateDeNaissance",
                table: "AspNetUsers",
                type: "NVARCHAR2(10)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AddColumn<string>(
                name: "NomAdmin",
                table: "AspNetUsers",
                type: "NVARCHAR2(40)",
                maxLength: 40,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomAdmin",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Cin",
                table: "Operateurs",
                newName: "CIN");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeNaissance",
                table: "AspNetUsers",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }
    }
}
