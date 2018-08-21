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
    public class CategoriaProductoController : Controller
    {
        private readonly ICategoriaProductoService _categoria;

        public CategoriaProductoController(ICategoriaProductoService categoria)
        {
            _categoria = categoria;
        }

        [HttpPost("categoriasProductos/listar")]
        public async Task<IActionResult> GetAll([FromBody] DataGrid data)
        {
            return Ok(
                await _categoria.ListarCategorias(data)
            );
        }

        [HttpGet("categoriasProductos/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _categoria.ObtenerCategoria(id)
            );

        }

        [HttpPost("categoriasProductos")]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaProductoDto model)
        {
            return Ok(
                await _categoria.CrearCategoria(model)
            );
        }

        [HttpDelete("categoriasProductos/{id}")]
        public async Task<IActionResult> Remove(
            int id
        )
        {
            return Ok(
                await _categoria.EliminarCategoria(id)
            );

        }
    }
}