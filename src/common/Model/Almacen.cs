using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Almacen
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public CategoriaAlmacen CategoriaAlmacen { get; set; }
        public int CategoriaAlmacenId { get; set; }

        public Producto Producto { get; set; } 
        public int ProductoId { get; set; }
    }
}
