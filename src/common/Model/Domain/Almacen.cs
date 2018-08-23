using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class Almacen : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }

        public Producto Producto { get; set; } 
        public int ProductoId { get; set; }

        public bool Deleted { get; set; }
    }
}
