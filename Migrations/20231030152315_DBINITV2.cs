using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class DBINITV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Servicios_IdService",
                table: "Tramites");

            migrationBuilder.DropTable(
                name: "DocumentoTramiteModel");

            migrationBuilder.DropIndex(
                name: "IX_Tramites_IdService",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "IdService",
                table: "Tramites");

            migrationBuilder.AddColumn<int>(
                name: "IdDocumento",
                table: "Tramites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DetalleTramiteServicio",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTramite = table.Column<int>(type: "int", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleTramiteServicio", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleTramiteServicio_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleTramiteServicio_Tramites_IdTramite",
                        column: x => x.IdTramite,
                        principalTable: "Tramites",
                        principalColumn: "IdTramite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdDocumento",
                table: "Tramites",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTramiteServicio_IdServicio",
                table: "DetalleTramiteServicio",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTramiteServicio_IdTramite",
                table: "DetalleTramiteServicio",
                column: "IdTramite");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Documentos_IdDocumento",
                table: "Tramites",
                column: "IdDocumento",
                principalTable: "Documentos",
                principalColumn: "IdDocument",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tramites_Documentos_IdDocumento",
                table: "Tramites");

            migrationBuilder.DropTable(
                name: "DetalleTramiteServicio");

            migrationBuilder.DropIndex(
                name: "IX_Tramites_IdDocumento",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "IdDocumento",
                table: "Tramites");

            migrationBuilder.AddColumn<int>(
                name: "IdService",
                table: "Tramites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentoTramiteModel",
                columns: table => new
                {
                    DocumentosIdDocument = table.Column<int>(type: "int", nullable: false),
                    TramitesIdTramite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentoTramiteModel", x => new { x.DocumentosIdDocument, x.TramitesIdTramite });
                    table.ForeignKey(
                        name: "FK_DocumentoTramiteModel_Documentos_DocumentosIdDocument",
                        column: x => x.DocumentosIdDocument,
                        principalTable: "Documentos",
                        principalColumn: "IdDocument",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentoTramiteModel_Tramites_TramitesIdTramite",
                        column: x => x.TramitesIdTramite,
                        principalTable: "Tramites",
                        principalColumn: "IdTramite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdService",
                table: "Tramites",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoTramiteModel_TramitesIdTramite",
                table: "DocumentoTramiteModel",
                column: "TramitesIdTramite");

            migrationBuilder.AddForeignKey(
                name: "FK_Tramites_Servicios_IdService",
                table: "Tramites",
                column: "IdService",
                principalTable: "Servicios",
                principalColumn: "IdServicio");
        }
    }
}
