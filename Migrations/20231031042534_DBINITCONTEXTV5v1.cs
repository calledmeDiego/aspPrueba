using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITCONTEXTV5v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Documentos_IdDocumento",
                table: "Tramites");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Persona_IdUsuario",
                table: "Tramites");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Usuario_UsuarioIdPerson",
                table: "Tramites");

            migrationBuilder.DropIndex(
                name: "IX_Tramites_UsuarioIdPerson",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "UsuarioIdPerson",
                table: "Tramites");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumento",
                table: "Tramites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Documentos_IdDocumento",
                table: "Tramites",
                column: "IdDocumento",
                principalTable: "Documentos",
                principalColumn: "IdDocument");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Usuario_IdUsuario",
                table: "Tramites",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Documentos_IdDocumento",
                table: "Tramites");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Usuario_IdUsuario",
                table: "Tramites");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumento",
                table: "Tramites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdPerson",
                table: "Tramites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_UsuarioIdPerson",
                table: "Tramites",
                column: "UsuarioIdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Documentos_IdDocumento",
                table: "Tramites",
                column: "IdDocumento",
                principalTable: "Documentos",
                principalColumn: "IdDocument",
                onDelete: ReferentialAction.Cascade);

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
    }
}
