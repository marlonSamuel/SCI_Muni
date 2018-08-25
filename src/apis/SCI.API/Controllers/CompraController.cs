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
    public class CompraController : Controller
    {
        private readonly ICompraService _compra;

        public CompraController(ICompraService compra)
        {
            _compra = compra;
        }

        [HttpPost("compras/listar")]
        public async Task<IActionResult> GetAll([FromBody] DataGrid data)
        {
            return Ok(
                await _compra.ListarCompras(data)
            );
        }

        [HttpGet("compras/listar/{id}")]
        public async Task<IActionResult> GetDetalles(
            int id
        )
        {
            return Ok(
                await _compra.ListarDetalleCompra(id)
            );

        }

        [HttpGet("compras/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _compra.ObtenerCompra(id)
            );

        }

        [HttpPost("compras")]
        public async Task<IActionResult> Create([FromBody] CompraCreateDto model)
        {
            return Ok(
                await _compra.CrearCompra(model)
            );
        }

        [HttpDelete("compras/{id}")]
        public async Task<IActionResult> Remove(
            int id
        )
        {
            return Ok(
                await _compra.AnularCompra(id)
            );

        }
    }
}