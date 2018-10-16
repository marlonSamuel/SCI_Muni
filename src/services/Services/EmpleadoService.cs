using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Model.Shared;
using Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmpleadoService
    {
        Task<DataGridResponse> ListarEmpleados(DataGrid grid);
        Task<Empleado> ObtenerEmpleado(int Id);
        Task<bool> CrearEmpleado(EmpleadoCreateDto model);
        Task<bool> EliminarEmpleado(int id);
        List<Empleado> Listar();
    }

    public class EmpleadoService : IEmpleadoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EmpleadoService(
            ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment
        )
        {
            _context = context;
        }


        //listar todos los empleados
        public List<Empleado> Listar()
        {
            var list = new List<Empleado>();

            list = _context.Empleado.ToList();
              
            return list;
        }

        public async Task<DataGridResponse> ListarEmpleados(DataGrid grid)
        {
            grid.Initialize();

            try
            {
                var query = (
                    from e in _context.Empleado
                    join c in _context.Cargo on e.CargoId equals c.Id
                    join d in _context.Departamento on e.DepartamentoId equals d.Id
                    select new
                    {
                        empladoId = e.Id,
                        primer_nombre = e.Primer_nombre,
                        segundo_nombre = e.Segundo_nombre,
                        primer_apellido = e.Primer_apellido,
                        segundo_apellido = e.Segundo_apellido,
                        Email = e.Email,
                        Foto = e.Foto,
                        Telefono = e.Telefono,
                        Direccion = e.Direccion,
                        Cargo = c.Nombre,
                        Departamento = d.Nombre,
                        CargoId = c.Id,
                        DepartamentoId = d.Id
                    }
                ).Select(x => new EmpleadoListDto
                {
                    empleadoId = x.empladoId,
                    primer_nombre = x.primer_nombre,
                    segundo_nombre = x.segundo_nombre,
                    primer_apellido = x.primer_apellido,
                    segundo_apellido = x.segundo_apellido,
                    foto = x.Foto,
                    email = x.Email,
                    direccion = x.Direccion,
                    telefono = x.Telefono,
                    cargo = x.Cargo,
                    departamento = x.Departamento,
                    cargoId = x.CargoId,
                    departamentoId = x.DepartamentoId
                }).AsQueryable();

                var data = await query.Skip(grid.Page)
                                .Take(grid.RowsPerPage)
                                .ToListAsync();

                var total = await query.CountAsync();

                grid.SetData(data, total);
            }
            catch (Exception e)
            {
                // Error logging
            }

            return grid.Response();
        }

        //obtene empleado por id
        public async Task<Empleado> ObtenerEmpleado(int Id)
        {
            var result = new Empleado();

            try
            {
                result = await _context.Empleado.Where(x => x.Id == Id).SingleAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar empleado
        public async Task<bool> CrearEmpleado(EmpleadoCreateDto model)
        {
            var result = false;

            try
            {
                if (model.empleadoId > 0)
                {
                    _context.Empleado.Update(new Empleado
                    {
                        Id = model.empleadoId,
                        Primer_nombre = model.primer_nombre,
                        Segundo_nombre = model.segundo_nombre,
                        Primer_apellido = model.primer_apellido,
                        Segundo_apellido = model.segundo_apellido,
                        Foto = model.foto,
                        Direccion = model.direccion,
                        Telefono = model.telefono,
                        Email = model.email,
                        CargoId = model.cargoId,
                        DepartamentoId = model.departamentoId
                        
                    });
                }
                else
                {
                    _context.Empleado.Add(new Empleado
                    {
                        Primer_nombre = model.primer_nombre,
                        Segundo_nombre = model.segundo_nombre,
                        Primer_apellido = model.primer_apellido,
                        Segundo_apellido = model.segundo_apellido,
                        Foto = model.foto,
                        Direccion = model.direccion,
                        Telefono = model.telefono,
                        Email = model.email,
                        CargoId = model.cargoId,
                        DepartamentoId = model.departamentoId
                    });
                }

                await _context.SaveChangesAsync();

                result = true;
            }
            catch (Exception)
            {

            }

            return result;
        }

        //Eliminar cargo a nivel logico
        public async Task<bool> EliminarEmpleado(int id)
        {
            var result = false;

            try
            {
                var originalEntry = await _context.Empleado.SingleOrDefaultAsync(x =>
                    x.Id == id
                );

                /*
                 * Aplicamos softdeleted para hacer borrado solo a nivel lógico.
                 * En nuestro ApplicationDbContext aplicamos filtros, estos excluirán
                 * cualquier consulta donde el Deleted = True
                 */

                if (originalEntry != null)
                {
                    originalEntry.Deleted = true;
                    _context.Update(originalEntry);

                    await _context.SaveChangesAsync();

                    result = true;
                }
            }
            catch (Exception e)
            {
                // Error logging
            }

            return result;
        }
    }
}
