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
    public class CategoriaAlmacenController : Controller
    {
        private readonly ICategoriaAlmacenService _categoria;

        public CategoriaAlmacenController(ICategoriaAlmacenService categoria)
        {
            _categoria = categoria;
        }

        [HttpPost("categorias/listar")]
        public async Task<IActionResult> GetAll([FromBody] DataGrid data)
        {
            return Ok(
                await _categoria.ListarCategorias(data)
            );
        }

        [HttpGet("categorias/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _categoria.ObtenerCategoria(id)
            );

        }

        [HttpPost("categorias")]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaAlmacenDto model)
        {
            return Ok(
                await _categoria.CrearCategoria(model)
            );
        }

        [HttpDelete("categorias/{id}")]
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