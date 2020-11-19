using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntelutionsTest.Data.ModelDB
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DBContext()
        {
        }

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=dbIntelutions;Integrated Security=True");
                //optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TipoPermiso>(entity =>
        //    {
        //        entity.ToTable("TipoPermiso");

        //        entity.Property(e => e.Descripcion)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        //entity.Property(e => e.RequirementDate).HasColumnType("datetime");
        //    });

        //    modelBuilder.Entity<Permiso>(entity =>
        //    {
        //        entity.ToTable("Permiso");

        //        entity.Property(e => e.EmpleadoNombre)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.EmpleadoApellidos)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.FechaPermiso)
        //            .IsRequired()
        //            .HasColumnType("datetime");

        //        entity.HasOne(d => d.TipoPermiso)
        //              .WithMany(p => p.Permisos)
        //              .HasForeignKey(d => d.TipoPermiso)
        //              .OnDelete(DeleteBehavior.ClientSetNull)
        //              .HasConstraintName("FK_UserRoles_Roles");
        //    });

        //    modelBuilder.Entity<Role>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(100);
        //    });

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.Property(e => e.Email)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.Lastname)
        //            .HasMaxLength(100)
        //            .IsFixedLength(true);

        //        entity.Property(e => e.Name)
        //            .HasMaxLength(100)
        //            .IsFixedLength(true);

        //        entity.Property(e => e.Password)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.Salt)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<UserRole>(entity =>
        //    {
        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.UserRoles)
        //            .HasForeignKey(d => d.RoleId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_UserRoles_Roles");

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.UserRoles)
        //            .HasForeignKey(d => d.UserId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_UserRoles_Users");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
