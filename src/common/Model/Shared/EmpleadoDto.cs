
namespace Model.Shared
{
    public class EmpleadoListDto
    {
        public int empleadoId { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string foto { get; set; }
        public string direccion { get; set; }
        public string cargo { get; set; }
        public string departamento { get; set; }
        public int cargoId { get; set; }
        public int departamentoId { get; set; }
    }

    public class EmpleadoCreateDto
    {
        public int empleadoId { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string foto { get; set; }
        public string direccion { get; set; }
        public int cargoId { get; set; }
        public int departamentoId { get; set; }
    }
}
