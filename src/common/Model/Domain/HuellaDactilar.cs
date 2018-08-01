using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class HuellaDactilar : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public byte[] Huella { get; set; }

        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }

        public bool Deleted { get; set; }
    }
}
