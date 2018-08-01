using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class AlmacenConfig
    {
        public AlmacenConfig(EntityTypeBuilder<Almacen> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Tipo).IsRequired().HasMaxLength(1);
            entityBuilder.Property(x => x.Stock).IsRequired();
        }
    }
}
