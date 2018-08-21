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
    public interface ICategoriaAlmacenService
    {
        Task<DataGridResponse> ListarCategorias(DataGrid grid);
        Task<CategoriaAlmacen> ObtenerCategoria(int Id);
        Task<bool> CrearCategoria(CreateCategoriaAlmacenDto model);
        Task<bool> EliminarCategoria(int id);
    }

    public class CategoriaAlmacenService : ICategoriaAlmacenService
    {
        private readonly ApplicationDbContext _context;

        public CategoriaAlmacenService(ApplicationDbContext context)
        {
            _context = context;
        }

        //listar categorias de almacen
        public async Task<DataGridResponse> ListarCategorias(DataGrid grid)
        {
            grid.Initialize();

            try
            {
                var query = _context.CategoriaAlmacen.AsQueryable();

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

        //obtene categoria por id
        public async Task<CategoriaAlmacen> ObtenerCategoria(int Id)
        {
            var result = new CategoriaAlmacen();

            try
            {
                result = await _context.CategoriaAlmacen.Where(x => x.Id == Id).SingleAsync();


            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar nuevo cargo
        public async Task<bool> CrearCategoria(CreateCategoriaAlmacenDto model)
        {
            var result = false;

            try
            {
                if (model.Id > 0)
                {
                    _context.CategoriaAlmacen.Update(new CategoriaAlmacen
                    {
                        Id = model.Id,
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion
                    });
                }
                else
                {
                    _context.CategoriaAlmacen.Add(new CategoriaAlmacen
                    {
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion
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
        public async Task<bool> EliminarCategoria(int id)
        {
            var result = false;

            try
            {
                var originalEntry = await _context.CategoriaAlmacen.SingleOrDefaultAsync(x =>
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
