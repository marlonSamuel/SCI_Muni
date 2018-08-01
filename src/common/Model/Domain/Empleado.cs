using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Empleado : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Primer_nombre { get; set; }
        public string Segundo_nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }

        public Cargo Cargo { get; set; }
        public int CargoId { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }

        public bool Deleted { get; set; }
    }
}
