using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITCONTEXTV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Tramites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdPerson",
                table: "Tramites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdUsuario",
                table: "Tramites",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_UsuarioIdPerson",
                table: "Tramites",
                column: "UsuarioIdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Persona_IdUsuario",
                table: "Tramites",
                column: "IdUsuario",
                principalTable: "Persona",
                principalColumn: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Usuario_UsuarioIdPerson",
                table: "Tramites",
                column: "UsuarioIdPerson",
                principalTable: "Usuario",
                principalColumn: "IdPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Persona_IdUsuario",
                table: "Tramites");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Usuario_UsuarioIdPerson",
                table: "Tramites");

            migrationBuilder.DropIndex(
                name: "IX_Tramites_IdUsuario",
                table: "Tramites");

            migrationBuilder.DropIndex(
                name: "IX_Tramites_UsuarioIdPerson",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "UsuarioIdPerson",
                table: "Tramites");
        }
    }
}
