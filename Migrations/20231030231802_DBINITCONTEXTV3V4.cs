using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITCONTEXTV3V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Usuario_IdUsuario",
                table: "Tramites");

            migrationBuilder.DropIndex(
                name: "IX_Tramites_IdUsuario",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Tramites");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Tramites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdUsuario",
                table: "Tramites",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Usuario_IdUsuario",
                table: "Tramites",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
