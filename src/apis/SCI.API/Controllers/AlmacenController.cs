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
    public class AlmacenController : Controller
    {
        private readonly IProductoService _producto;

        public AlmacenController(IProductoService producto)
        {
            _producto = producto;
        }

        [HttpPost("productos/listar/{id}")]
        public async Task<IActionResult> GetAll(int id, [FromBody] DataGrid data)
        {
            return Ok(
                await _producto.ListarProductos(id, data)
            );
        }

        [HttpGet("productos/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _producto.ObtenerProducto(id)
            );

        }

        [HttpPost("productos/guardar")]
        public async Task<IActionResult> Create([FromBody] ProductoCreateDto model)
        {
            return Ok(
                await _producto.CrearProducto(model)
            );
        }

        [HttpDelete("productos/{id}/{almacenId}")]
        public async Task<IActionResult> Remove(
            int id, int almacenId
        )
        {
            return Ok(
                await _producto.EliminarProducto(id, almacenId)
            );

        }
    }
}