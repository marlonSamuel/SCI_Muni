using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Shared;
using Services;

namespace SCI.API.Controllers
{
    [Authorize]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleado;

        public EmpleadoController(IEmpleadoService empleado)
        {
            _empleado = empleado;
        }

        [HttpPost("empleados/listar")]
        public async Task<IActionResult> GetAll([FromBody] DataGrid data)
        {
            return Ok(
                await _empleado.ListarEmpleados(data)
            );
        }

        [HttpGet("empleados/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _empleado.ObtenerEmpleado(id)
            );

        }

        [HttpPost("empleados")]
        public async Task<IActionResult> Create([FromBody] EmpleadoCreateDto model)
        {
            return Ok(
                await _empleado.CrearEmpleado(model)
            );
        }

        [HttpDelete("empleados/{id}")]
        public async Task<IActionResult> Remove(
            int id
        )
        {
            return Ok(
                await _empleado.EliminarEmpleado(id)
            );

        }
    }
}