﻿using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class Producto : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
        public int Descripcion { get; set; }

        public CategoriaProducto CategoriaProducto { get; set; }
        public int CategoriaProductoId { get; set; }

        public bool Deleted { get; set; }
    }
}
