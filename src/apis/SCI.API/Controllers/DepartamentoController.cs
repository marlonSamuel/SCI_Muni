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
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService _departamento;

        public DepartamentoController(IDepartamentoService departamento)
        {
            _departamento = departamento;
        }

        [HttpGet("departamentos")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _departamento.ListarDepartamentos()
            );
        }

        [HttpGet("departamentos/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _departamento.ObtenerDepartamento(id)
            );

        }

        [HttpPost("departamentos")]
        public async Task<IActionResult> Create([FromBody] DepartamentoCreateDto model)
        {
            return Ok(
                await _departamento.CrearDepartamento(model)
            );
        }

        [HttpDelete("departamentos/{id}")]
        public async Task<IActionResult> Remove(
            int id
        )
        {
            return Ok(
                await _departamento.EliminarDepartamento(id)
            );

        }
    }
}