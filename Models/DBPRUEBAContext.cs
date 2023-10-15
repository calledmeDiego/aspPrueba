using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SustentacionASPNETCoreMVC.Models
{
    public partial class DBPRUEBAContext : DbContext
    {
        public DBPRUEBAContext()
        {
        }

        public DBPRUEBAContext(DbContextOptions<DBPRUEBAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__AREA__2FC141AAE923A006");

                entity.ToTable("AREA");

                entity.Property(e => e.NameArea)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            }); 

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__USUARIO__B7C9263843BC5D6B");

                entity.ToTable("USUARIO");

                entity.Property(e => e.DateRegister).HasColumnType("date");

                entity.Property(e => e.NameComplete)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                
                entity.HasOne(d => d.OArea)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK__USUARIO__IdArea__71D1E811");
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
