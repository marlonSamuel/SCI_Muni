using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class CategoriaProducto : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public bool Deleted { get; set; }
    }
}
