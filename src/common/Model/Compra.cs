using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Compra
    {
        public int Id { get; set; } 
        public DateTime? Fecha { get; set; }
        public Decimal Total_Compra { get; set; }
        public string Estado { get; set; }

        public Proveedor Proveedor { get; set; }
        public int ProveedorId { get; set; }
    }
}
