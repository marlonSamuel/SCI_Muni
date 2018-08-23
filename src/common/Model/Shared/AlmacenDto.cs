using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shared
{
    public class ProductoListDto
    {
        public int Id { get; set; }
        public int AlmacenId { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public int CategoriaId { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }

    public class ProductoCreateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
        public string Categoria { get; set; }
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }

        //campos almacen
        public int AlmacenId { get; set; }
        public int CategoriaAlmacenId { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }
}
