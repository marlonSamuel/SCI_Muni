using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public Decimal? Precio_Compra { get; set; }

        public Compra Compra { get; set; }
        public int CompraId { get; set; }

        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
    }
}
