﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shared
{
    class DepartamentoDto
    {
    }

    public class DepartamentoCreateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
