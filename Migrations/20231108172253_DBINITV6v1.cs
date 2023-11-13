using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITV6v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleTramiteServicio_Servicios_IdServicio",
                table: "DetalleTramiteServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleTramiteServicio_Tramites_IdTramite",
                table: "DetalleTramiteServicio");

            migrationBuilder.AlterColumn<int>(
                name: "IdTramite",
                table: "DetalleTramiteServicio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdServicio",
                table: "DetalleTramiteServicio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DetalleTramiteServicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRecibo",
                table: "DetalleTramiteServicio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "DetalleTramiteServicio",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Recibo",
                columns: table => new
                {
                    IdRecibo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    NumRecibo = table.Column<int>(type: "int", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.IdRecibo);
                    table.ForeignKey(
                        name: "FK_Recibo_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTramiteServicio_IdRecibo",
                table: "DetalleTramiteServicio",
                column: "IdRecibo");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_IdCliente",
                table: "Recibo",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleTramiteServicio_Recibo_IdRecibo",
                table: "DetalleTramiteServicio",
                column: "IdRecibo",
                principalTable: "Recibo",
                principalColumn: "IdRecibo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleTramiteServicio_Servicios_IdServicio",
                table: "DetalleTramiteServicio",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleTramiteServicio_Tramites_IdTramite",
                table: "DetalleTramiteServicio",
                column: "IdTramite",
                principalTable: "Tramites",
                principalColumn: "IdTramite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleTramiteServicio_Recibo_IdRecibo",
                table: "DetalleTramiteServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleTramiteServicio_Servicios_IdServicio",
                table: "DetalleTramiteServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleTramiteServicio_Tramites_IdTramite",
                table: "DetalleTramiteServicio");

            migrationBuilder.DropTable(
                name: "Recibo");

            migrationBuilder.DropIndex(
                name: "IX_DetalleTramiteServicio_IdRecibo",
                table: "DetalleTramiteServicio");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DetalleTramiteServicio");

            migrationBuilder.DropColumn(
                name: "IdRecibo",
                table: "DetalleTramiteServicio");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "DetalleTramiteServicio");

            migrationBuilder.AlterColumn<int>(
                name: "IdTramite",
                table: "DetalleTramiteServicio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdServicio",
                table: "DetalleTramiteServicio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleTramiteServicio_Servicios_IdServicio",
                table: "DetalleTramiteServicio",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleTramiteServicio_Tramites_IdTramite",
                table: "DetalleTramiteServicio",
                column: "IdTramite",
                principalTable: "Tramites",
                principalColumn: "IdTramite",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
