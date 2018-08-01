using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class Almacen : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Stock { get; set; }

        public CategoriaAlmacen CategoriaAlmacen { get; set; }
        public int CategoriaAlmacenId { get; set; }

        public Producto Producto { get; set; } 
        public int ProductoId { get; set; }

        public bool Deleted { get; set; }
    }
}
