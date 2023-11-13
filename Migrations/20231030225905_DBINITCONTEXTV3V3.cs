using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITCONTEXTV3V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Cliente_IdCliente",
                table: "Tramites");

            migrationBuilder.DropIndex(
                name: "IX_Tramites_IdCliente",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Tramites");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Tramites",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Tramites");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Tramites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdCliente",
                table: "Tramites",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Cliente_IdCliente",
                table: "Tramites",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
