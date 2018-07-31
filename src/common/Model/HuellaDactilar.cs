using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class HuellaDactilar
    {
        public int Id { get; set; }
        public byte[] Huella { get; set; }

        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }
    }
}
