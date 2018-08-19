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
    public interface IDepartamentoService
    {
        Task<IEnumerable<Departamento>> ListarDepartamentos();
        Task<Departamento> ObtenerDepartamento(int Id);
        Task<bool> CrearDepartamento(DepartamentoCreateDto model);
        Task<bool> EliminarDepartamento(int Id);
    }

    public class DepartamentoService : IDepartamentoService
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        //metodo para obtener registros 
        public async Task<IEnumerable<Departamento>> ListarDepartamentos()
        {
            var list = new List<Departamento>();

            try
            {
                var query = _context.Departamento;

                list = await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        //obtene departamento por id
        public async Task<Departamento> ObtenerDepartamento(int Id)
        {
            var result = new Departamento();

            try
            {
                result = await _context.Departamento.Where(x => x.Id == Id).SingleAsync();

                
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar nuevo departamento
        public async Task<bool> CrearDepartamento(DepartamentoCreateDto model)
        {
            var result = false;

            try
            {
                if(model.Id > 0)
                {
                    _context.Departamento.Update(new Departamento
                    {
                        Id = model.Id,
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion
                    });
                }
                else
                {
                    _context.Departamento.Add(new Departamento
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

        //Eliminar departamento
        public async Task<bool> EliminarDepartamento( int id)
        {
            var result = false;

            try
            {
                var originalEntry = await _context.Departamento.SingleOrDefaultAsync(x =>
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
