using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscriminadorDocumento",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Documentos");

            migrationBuilder.AddColumn<string>(
                name: "DiscriminatorDocumento",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscriminatorDocumento",
                table: "Documentos");

            migrationBuilder.AddColumn<int>(
                name: "DiscriminadorDocumento",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
