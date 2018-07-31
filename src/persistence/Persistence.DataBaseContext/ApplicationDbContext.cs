using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        {
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

    }
}
