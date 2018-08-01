using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class CategoriaProductoConfig
    {
        public CategoriaProductoConfig(EntityTypeBuilder<CategoriaProducto> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(25);
            entityBuilder.Property(x => x.Descripcion).HasMaxLength(500);
        }
    }
}
