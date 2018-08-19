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
    public class CargoController : Controller
    {
        private readonly ICargoService _cargo;

        public CargoController(ICargoService cargo)
        {
            _cargo = cargo;
        }

        [HttpPost("cargos/listar")]
        public async Task<IActionResult> GetAll([FromBody] DataGrid data)
        {
            return Ok(
                await _cargo.ListarCargos(data)
            );
        }

        [HttpGet("cargos/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _cargo.ObtenerCargo(id)
            );

        }

        [HttpPost("cargos")]
        public async Task<IActionResult> Create([FromBody] CargoCreateDto model)
        {
            return Ok(
                await _cargo.CrearCargo(model)
            );
        }

        [HttpDelete("cargos/{id}")]
        public async Task<IActionResult> Remove(
            int id
        )
        {
            return Ok(
                await _cargo.EliminarCargo(id)
            );

        }
    }
}