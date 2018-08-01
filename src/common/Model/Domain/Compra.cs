using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class Compra : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; } 
        public DateTime? Fecha { get; set; }
        public Decimal Total_Compra { get; set; }
        public int No_Serie { get; set; }
        public string Estado { get; set; }

        public Proveedor Proveedor { get; set; }
        public int ProveedorId { get; set; }

        public bool Deleted { get; set; }
    }
}
