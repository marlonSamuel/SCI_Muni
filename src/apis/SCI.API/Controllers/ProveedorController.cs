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
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _proveedor;

        public ProveedorController(IProveedorService proveedor)
        {
            _proveedor = proveedor;
        }

        [HttpPost("proveedores/listar")]
        public async Task<IActionResult> GetAll([FromBody] DataGrid data)
        {
            return Ok(
                await _proveedor.ListarProveedores(data)
            );
        }

        [HttpGet("proveedores/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _proveedor.ObtenerProveedor(id)
            );

        }

        [HttpPost("proveedores")]
        public async Task<IActionResult> Create([FromBody] CreateProveedorDto model)
        {
            return Ok(
                await _proveedor.CrearProveedor(model)
            );
        }

        [HttpDelete("proveedores/{id}")]
        public async Task<IActionResult> Remove(
            int id
        )
        {
            return Ok(
                await _proveedor.EliminarProveedor(id)
            );

        }
    }
}