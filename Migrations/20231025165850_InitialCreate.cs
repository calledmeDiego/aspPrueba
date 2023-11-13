using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    IdDocument = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tramitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriminadorDocumento = table.Column<int>(type: "int", nullable: false),
                    EscrituraPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtorgamientoPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavorecimientoPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaSuscrito = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExNotario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aclaramiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FondoDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeccionDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerieDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreApe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoTramite = table.Column<int>(type: "int", nullable: true),
                    TipoTramite = table.Column<int>(type: "int", nullable: true),
                    IdCarnet = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuaderno = table.Column<int>(type: "int", nullable: true),
                    Libro = table.Column<int>(type: "int", nullable: true),
                    Seccion = table.Column<int>(type: "int", nullable: true),
                    Anio = table.Column<int>(type: "int", nullable: true),
                    Escribano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoInvestigador_FondoDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expediente = table.Column<int>(type: "int", nullable: true),
                    Paqt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.IdDocument);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Cellphone = table.Column<int>(type: "int", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Selected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "TipoCliente",
                columns: table => new
                {
                    IdTipoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCliente", x => x.IdTipoCliente);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PasswordUser = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdArea = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Usuario_Area_IdArea",
                        column: x => x.IdArea,
                        principalTable: "Area",
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Persona",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    País = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Extranjero = table.Column<bool>(type: "bit", nullable: false),
                    Carnet = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Persona",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "FK_Cliente_TipoCliente_IdTipoCliente",
                        column: x => x.IdTipoCliente,
                        principalTable: "TipoCliente",
                        principalColumn: "IdTipoCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tramites",
                columns: table => new
                {
                    IdTramite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    FechaFinalizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoTramite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    EsInvestigador = table.Column<bool>(type: "bit", nullable: false),
                    TratamientoDatos = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CantidadServicios = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramites", x => x.IdTramite);
                    table.ForeignKey(
                        name: "FK_Tramites_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tramites_Servicios_IdService",
                        column: x => x.IdService,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio");
                    table.ForeignKey(
                        name: "FK_Tramites_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Cliente_IdTipoCliente",
                table: "Cliente",
                column: "IdTipoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoTramiteModel_TramitesIdTramite",
                table: "DocumentoTramiteModel",
                column: "TramitesIdTramite");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdCliente",
                table: "Tramites",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdService",
                table: "Tramites",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdUsuario",
                table: "Tramites",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdArea",
                table: "Usuario",
                column: "IdArea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentoTramiteModel");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Tramites");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoCliente");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
