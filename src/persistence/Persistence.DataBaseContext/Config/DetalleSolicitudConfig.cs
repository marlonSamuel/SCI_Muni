using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class DetalleSolicitudConfig
    {
        public DetalleSolicitudConfig(EntityTypeBuilder<DetalleSolicitud> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Cantidad_Solicitada).IsRequired();
        }
    }
}
