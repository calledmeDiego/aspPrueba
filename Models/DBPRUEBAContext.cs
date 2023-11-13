using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SustentacionASPNETCoreMVC.Models.Tramites;

namespace SustentacionASPNETCoreMVC.Models;

public partial class DBPRUEBAContext : DbContext
{
    public DBPRUEBAContext()
    {
    }

    public DBPRUEBAContext(DbContextOptions<DBPRUEBAContext> options)
        : base(options)
    {
    }

    public DbSet<Area> Areas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<TipoCliente> TipoClientes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DocumentoCliente> DocumentoClientes { get; set; }
    public DbSet<DocumentoInvestigador> DocumentoInvestigadores { get; set; }
    public DbSet<TramiteModel> Tramites { get; set; }
    public DbSet<ServicioTramite> Servicios { get; set; }
    public DbSet<DetalleTramiteServicio> DetalleTramiteServicios { get; set; }
    public DbSet<Recibo> Recibos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>().ToTable(nameof(Area));
        modelBuilder.Entity<Persona>().ToTable(nameof(Persona)).Property(p => p.FechaNacimiento).HasColumnType("date"); ;

        modelBuilder.Entity<Cliente>().ToTable(nameof(Cliente));

        modelBuilder.Entity<TipoCliente>().ToTable(nameof(TipoCliente));
        modelBuilder.Entity<Usuario>().ToTable(nameof(Usuario));
        modelBuilder.Entity<Documento>().ToTable("Documentos")
            .HasDiscriminator<string>("DiscriminatorDocumento")
            .HasValue<DocumentoCliente>("Cliente")
            .HasValue<DocumentoInvestigador>("Investigador");

        modelBuilder.Entity<TramiteModel>().ToTable("Tramites");
        modelBuilder.Entity<ServicioTramite>().ToTable("Servicios");
        modelBuilder.Entity<DetalleTramiteServicio>().ToTable("DetalleTramiteServicio");
        modelBuilder.Entity<Recibo>().ToTable(nameof(Recibo));


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
