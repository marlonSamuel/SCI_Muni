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
    public class SolicitudController : Controller
    {
        private readonly ISolicitudService _solicitud;

        public SolicitudController(ISolicitudService solicitud)
        {
            _solicitud = solicitud;
        }

        [HttpPost("solicitudes/listar/{estado}")]
        public async Task<IActionResult> GetAll(string estado, [FromBody] DataGrid data)
        {
            return Ok(
                await _solicitud.ListarSolicitudes(data, estado)
            );
        }

        [HttpGet("solicitudes/listar/{id}")]
        public async Task<IActionResult> GetDetalles(
            int id
        )
        {
            return Ok(
                await _solicitud.ListarDetalleSolicitud(id)
            );

        }

        [HttpGet("solicitudes/{id}")]
        public async Task<IActionResult> Get(
            int id
        )
        {
            return Ok(
                await _solicitud.ObtenerSolicitud(id)
            );

        }

        [HttpPost("solicitudes")]
        public async Task<IActionResult> Create([FromBody] SolicitudCreateDto model)
        {
            return Ok(
                await _solicitud.CrearSolicitud(model)
            );
        }

        [HttpDelete("solicitudes/{id}")]
        public async Task<IActionResult> Remove(
            int id
        )
        {
            return Ok(
                await _solicitud.AnularSolicitud(id)
            );

        }

        //metodo para cambiar de estado
        [HttpGet("solicitudes/{id}/{estado}")]
        public async Task<IActionResult> ChangeStatus(
            int id, string estado
        )
        {
            return Ok(
                await _solicitud.CambiarEstado(id, estado)
            );

        }

        [HttpGet("solicitudes/correlativos/")]
        public async Task<IActionResult> GetCorrelativos(
            int id
        )
        {
            return Ok(
                await _solicitud.GetCorrrelativos()
            );

        }
    }
}