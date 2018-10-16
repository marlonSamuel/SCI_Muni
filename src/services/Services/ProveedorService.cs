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
    public interface IProveedorService
    {
        Task<DataGridResponse> ListarProveedores(DataGrid grid);
        Task<Proveedor> ObtenerProveedor(int Id);
        Task<bool> CrearProveedor(CreateProveedorDto model);
        Task<bool> EliminarProveedor(int id);
    }

    public class ProveedorService : IProveedorService
    {
        private readonly ApplicationDbContext _context;

        public ProveedorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataGridResponse> ListarProveedores(DataGrid grid)
        {
            grid.Initialize();

            try
            {
                var query = _context.Proveedor.AsQueryable();

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

        //obtene cargo por id
        public async Task<Proveedor> ObtenerProveedor(int Id)
        {
            var result = new Proveedor();

            try
            {
                result = await _context.Proveedor.Where(x => x.Id == Id).SingleAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar nuevo proveedor
        public async Task<bool> CrearProveedor(CreateProveedorDto model)
        {
            var result = false;

            try
            {
                if (model.Id > 0)
                {
                    _context.Proveedor.Update(new Proveedor
                    {
                        Id = model.Id,
                        Nombre = model.Nombre,
                        Telefono = model.Telefono,
                        Direccion = model.Direccion,
                        Email = model.Email,
                        Nit = model.Nit
                    });
                }
                else
                {
                    _context.Proveedor.Add(new Proveedor
                    {
                        Nombre = model.Nombre,
                        Telefono = model.Telefono,
                        Direccion = model.Direccion,
                        Email = model.Email,
                        Nit = model.Nit
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

        //Eliminar proveedor a nivel logico
        public async Task<bool> EliminarProveedor(int id)
        {
            var result = false;

            try
            {
                var originalEntry = await _context.Proveedor.SingleOrDefaultAsync(x =>
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
