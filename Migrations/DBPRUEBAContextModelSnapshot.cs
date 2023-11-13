﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SustentacionASPNETCoreMVC.Models;

#nullable disable

namespace SustentacionASPNETCoreMVC.Migrations
{
    [DbContext(typeof(DBPRUEBAContext))]
    partial class DBPRUEBAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Area", b =>
                {
                    b.Property<int>("IdArea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArea"), 1L, 1);

                    b.Property<string>("NameArea")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArea");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Persona", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerson"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Cargo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Cellphone")
                        .HasColumnType("int");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Domicilio")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdPerson");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.TipoCliente", b =>
                {
                    b.Property<int>("IdTipoCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoCliente"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTipoCliente");

                    b.ToTable("TipoCliente", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.DetalleTramiteServicio", b =>
                {
                    b.Property<int?>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdDetalle"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("IdRecibo")
                        .HasColumnType("int");

                    b.Property<int?>("IdServicio")
                        .HasColumnType("int");

                    b.Property<int?>("IdTramite")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDetalle");

                    b.HasIndex("IdRecibo");

                    b.HasIndex("IdServicio");

                    b.HasIndex("IdTramite");

                    b.ToTable("DetalleTramiteServicio", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.Documento", b =>
                {
                    b.Property<int>("IdDocument")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDocument"), 1L, 1);

                    b.Property<string>("DiscriminatorDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FondoDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeccionDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tramitante")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDocument");

                    b.ToTable("Documentos", (string)null);

                    b.HasDiscriminator<string>("DiscriminatorDocumento").HasValue("Documento");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.Recibo", b =>
                {
                    b.Property<int>("IdRecibo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecibo"), 1L, 1);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("NumRecibo")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdRecibo");

                    b.HasIndex("IdCliente");

                    b.ToTable("Recibo", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.ServicioTramite", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<bool>("Selected")
                        .HasColumnType("bit");

                    b.HasKey("IdServicio");

                    b.ToTable("Servicios", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.TramiteModel", b =>
                {
                    b.Property<int>("IdTramite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTramite"), 1L, 1);

                    b.Property<int>("CantidadServicios")
                        .HasColumnType("int");

                    b.Property<bool>("EsInvestigador")
                        .HasColumnType("bit");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFinalizado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdDocumento")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("TipoTramite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TratamientoDatos")
                        .HasColumnType("bit");

                    b.HasKey("IdTramite");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdDocumento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Tramites", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Cliente", b =>
                {
                    b.HasBaseType("SustentacionASPNETCoreMVC.Models.Persona");

                    b.Property<string>("Carnet")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Departamento")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Distrito")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Extranjero")
                        .HasColumnType("bit");

                    b.Property<int?>("IdTipoCliente")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("País")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Provincia")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("IdTipoCliente");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.DocumentoCliente", b =>
                {
                    b.HasBaseType("SustentacionASPNETCoreMVC.Models.Tramites.Documento");

                    b.Property<string>("Aclaramiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DiaSuscrito")
                        .HasColumnType("datetime2");

                    b.Property<string>("Distrito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EscrituraPersona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExNotario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavorecimientoPersona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaFD")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTipoTramite")
                        .HasColumnType("int");

                    b.Property<string>("NombreApe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtorgamientoPersona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerieDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoTramite")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.DocumentoInvestigador", b =>
                {
                    b.HasBaseType("SustentacionASPNETCoreMVC.Models.Tramites.Documento");

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("Cuaderno")
                        .HasColumnType("int");

                    b.Property<string>("Escribano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Expediente")
                        .HasColumnType("int");

                    b.Property<int>("IdCarnet")
                        .HasColumnType("int");

                    b.Property<string>("Leg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Libro")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumCarnet")
                        .HasColumnType("int");

                    b.Property<int>("Paqt")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Investigador");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Usuario", b =>
                {
                    b.HasBaseType("SustentacionASPNETCoreMVC.Models.Persona");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdArea")
                        .HasColumnType("int");

                    b.Property<string>("PasswordUser")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasIndex("IdArea");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.DetalleTramiteServicio", b =>
                {
                    b.HasOne("SustentacionASPNETCoreMVC.Models.Tramites.Recibo", "Recibo")
                        .WithMany()
                        .HasForeignKey("IdRecibo");

                    b.HasOne("SustentacionASPNETCoreMVC.Models.Tramites.ServicioTramite", "Servicio")
                        .WithMany("DetallesTramiteServicios")
                        .HasForeignKey("IdServicio");

                    b.HasOne("SustentacionASPNETCoreMVC.Models.Tramites.TramiteModel", "Tramite")
                        .WithMany("DetallesTramiteServicios")
                        .HasForeignKey("IdTramite");

                    b.Navigation("Recibo");

                    b.Navigation("Servicio");

                    b.Navigation("Tramite");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.Recibo", b =>
                {
                    b.HasOne("SustentacionASPNETCoreMVC.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.TramiteModel", b =>
                {
                    b.HasOne("SustentacionASPNETCoreMVC.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");

                    b.HasOne("SustentacionASPNETCoreMVC.Models.Tramites.Documento", "Documento")
                        .WithMany("Tramites")
                        .HasForeignKey("IdDocumento");

                    b.HasOne("SustentacionASPNETCoreMVC.Models.Usuario", "OUsuario")
                        .WithMany("Tramites")
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Cliente");

                    b.Navigation("Documento");

                    b.Navigation("OUsuario");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Cliente", b =>
                {
                    b.HasOne("SustentacionASPNETCoreMVC.Models.Persona", null)
                        .WithOne()
                        .HasForeignKey("SustentacionASPNETCoreMVC.Models.Cliente", "IdPerson")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SustentacionASPNETCoreMVC.Models.TipoCliente", "OCliente")
                        .WithMany("Clientes")
                        .HasForeignKey("IdTipoCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OCliente");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Usuario", b =>
                {
                    b.HasOne("SustentacionASPNETCoreMVC.Models.Area", "OArea")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdArea");

                    b.HasOne("SustentacionASPNETCoreMVC.Models.Persona", null)
                        .WithOne()
                        .HasForeignKey("SustentacionASPNETCoreMVC.Models.Usuario", "IdPerson")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("OArea");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Area", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.TipoCliente", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.Documento", b =>
                {
                    b.Navigation("Tramites");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.ServicioTramite", b =>
                {
                    b.Navigation("DetallesTramiteServicios");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Tramites.TramiteModel", b =>
                {
                    b.Navigation("DetallesTramiteServicios");
                });

            modelBuilder.Entity("SustentacionASPNETCoreMVC.Models.Usuario", b =>
                {
                    b.Navigation("Tramites");
                });
#pragma warning restore 612, 618
        }
    }
}
