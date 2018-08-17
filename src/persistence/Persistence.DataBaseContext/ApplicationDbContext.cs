using System.Data.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Model.Domain;
using Model.Domain.DbHelper;
using Persistence.DataBaseContext.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Persistence.DataBaseContext
{
    public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer<ApplicationDbContext>("Data Source = SENPAI\\SQLSERVER2017; Initial Catalog = DB_MUNI; User ID = sa; Password = marlon");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserFactory _currentUser;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserFactory currenUser = null
        ) : base(options)
        {
            _currentUser = currenUser;
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // My custom filters
            AddMyFilters(ref modelBuilder);

            // My fluent api contraints
            new ApplicationUserConfig(modelBuilder.Entity<ApplicationUser>());
            new AlmacenConfig(modelBuilder.Entity<Almacen>());
            new CargoConfig(modelBuilder.Entity<Cargo>());
            new CategoriaAlmacenConfig(modelBuilder.Entity<CategoriaAlmacen>());
            new CategoriaProductoConfig(modelBuilder.Entity<CategoriaProducto>());
            new CompraConfig(modelBuilder.Entity<Compra>());
            new DepartamentoConfig(modelBuilder.Entity<Departamento>());
            new DetalleCompraConfig(modelBuilder.Entity<DetalleCompra>());
            new DetalleSolicitudConfig(modelBuilder.Entity<DetalleSolicitud>());
            new EmpleadoConfig(modelBuilder.Entity<Empleado>());
            new HuellaDactilarConfig(modelBuilder.Entity<HuellaDactilar>());
            new ProductoConfig(modelBuilder.Entity<Producto>());
            new ProveedorConfig(modelBuilder.Entity<Proveedor>());
            new SolicitudConfig(modelBuilder.Entity<Solicitud>());
        }

        //seteamos nuestras tablas de la base de datos
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Solicitud> Solicitud { get; set; }
        public DbSet<DetalleSolicitud> DetalleSolicitud { get; set; }
        public DbSet<HuellaDactilar> HuellaDactilar { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<CategoriaAlmacen> CategoriaAlmacen { get; set; }
        public DbSet<Almacen> Almacen { get; set; }


        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            MakeAudit();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            MakeAudit();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is AuditEntity
                    && (
                    x.State == EntityState.Added
                    || x.State == EntityState.Modified
                )
            );
            
            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;

                if (entity != null)
                {
                    var date = DateTime.Now;
                    string userId = null;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }

        private void AddMyFilters(ref ModelBuilder modelBuilder)
        {
            #region SoftDeleted
            modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Almacen>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Cargo>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<CategoriaAlmacen>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<CategoriaProducto>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Compra>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Departamento>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<DetalleCompra>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<DetalleSolicitud>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Empleado>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<HuellaDactilar>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Producto>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Proveedor>().HasQueryFilter(x => !x.Deleted);
            modelBuilder.Entity<Solicitud>().HasQueryFilter(x => !x.Deleted);
            #endregion
        }

    }
}
