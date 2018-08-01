using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class Proveedor : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Nit { get; set; }
        public string Email { get; set; }

        public bool Deleted { get; set; }
    }
}
