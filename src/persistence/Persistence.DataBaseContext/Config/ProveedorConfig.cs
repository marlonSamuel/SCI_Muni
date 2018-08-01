using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class ProveedorConfig
    {
        public ProveedorConfig(EntityTypeBuilder<Proveedor> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Telefono).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Nit).HasMaxLength(50);
            entityBuilder.Property(x => x.Email).HasMaxLength(50);
        }
    }
}
