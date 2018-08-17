using Microsoft.AspNetCore.Hosting;
using Model.Domain;
using Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EmpleadoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EmpleadoService(
            ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment
        )
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //listar empleados
        public List<Empleado> ListarEmplados()
        {
            var list = new List<Empleado>();
            try
            {
                list = _context.Empleado.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }
    }
}
