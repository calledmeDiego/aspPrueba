using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITCONTEXTV6v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoInvestigador_FondoDoc",
                table: "Documentos");

            migrationBuilder.RenameColumn(
                name: "Seccion",
                table: "Documentos",
                newName: "NumCarnet");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Tramites",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFinalizado",
                table: "Tramites",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumCarnet",
                table: "Documentos",
                newName: "Seccion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Tramites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaFinalizado",
                table: "Tramites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentoInvestigador_FondoDoc",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
