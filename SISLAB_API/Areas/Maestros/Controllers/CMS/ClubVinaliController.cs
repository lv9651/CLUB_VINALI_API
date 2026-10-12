using Microsoft.AspNetCore.Mvc;
using SISLAB_API.Areas.Maestros.Models;
using SISLAB_API.Areas.Maestros.Services;

namespace SISLAB_API.Areas.Maestros.Controllers
{
    [ApiController]
    [Route("api/cms/club-vinali")]
    public class ClubVinaliController : ControllerBase
    {
        private readonly ClubVinaliService _service;

        public ClubVinaliController(ClubVinaliService service)
        {
            _service = service;
        }

        // ============================================================
        // CONTENIDO
        // ============================================================

        // GET: api/cms/club-vinali/contenido?seccion=HERO&idestado=1
        [HttpGet("contenido")]
        public async Task<IActionResult> Contenido_Listar([FromQuery] string? seccion, [FromQuery] int? idestado)
        {
            var data = await _service.Contenido_Listar(seccion, idestado);
            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/contenido/5
        [HttpGet("contenido/{id:int}")]
        public async Task<IActionResult> Contenido_Obtener(int id)
        {
            var data = await _service.Contenido_Obtener(id);
            if (data == null)
                return NotFound(ApiResponse<object>.Fail("Contenido no encontrado."));

            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/contenido/seccion/HERO
        [HttpGet("contenido/seccion/{seccion}")]
        public async Task<IActionResult> Contenido_PorSeccion(string seccion)
        {
            var data = await _service.Contenido_ObtenerPorSeccion(seccion);
            return Ok(ApiResponse<object>.Ok(data));
        }

        // POST: api/cms/club-vinali/contenido
        [HttpPost("contenido")]
        public async Task<IActionResult> Contenido_Insertar([FromBody] ContenidoDto dto)
        {
            var result = await _service.Contenido_Insertar(dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // PUT: api/cms/club-vinali/contenido/5
        [HttpPut("contenido/{id:int}")]
        public async Task<IActionResult> Contenido_Actualizar(int id, [FromBody] ContenidoDto dto)
        {
            var result = await _service.Contenido_Actualizar(id, dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // DELETE: api/cms/club-vinali/contenido/5
        [HttpDelete("contenido/{id:int}")]
        public async Task<IActionResult> Contenido_Eliminar(int id)
        {
            var result = await _service.Contenido_Eliminar(id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // ============================================================
        // CANJES
        // ============================================================

        // GET: api/cms/club-vinali/canjes?tipo=TRATAMIENTO&idestado=1
        [HttpGet("canjes")]
        public async Task<IActionResult> Canje_Listar([FromQuery] string? tipo, [FromQuery] int? idestado)
        {
            var data = await _service.Canje_Listar(tipo, idestado);
            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/canjes/5
        [HttpGet("canjes/{id:int}")]
        public async Task<IActionResult> Canje_Obtener(int id)
        {
            var data = await _service.Canje_Obtener(id);
            if (data == null)
                return NotFound(ApiResponse<object>.Fail("Canje no encontrado."));

            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/canjes/tipo/TRATAMIENTO
        [HttpGet("canjes/tipo/{tipo}")]
        public async Task<IActionResult> Canje_PorTipo(string tipo)
        {
            var data = await _service.Canje_ObtenerPorTipo(tipo);
            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/canjes/buscar-productos?q=hydra
        [HttpGet("canjes/buscar-productos")]
        public async Task<IActionResult> Canje_BuscarProductos([FromQuery] string? q)
        {
            var data = await _service.Canje_BuscarProductos(q);
            return Ok(ApiResponse<object>.Ok(data));
        }

        // POST: api/cms/club-vinali/canjes
        [HttpPost("canjes")]
        public async Task<IActionResult> Canje_Insertar([FromBody] CanjeDto dto)
        {
            var result = await _service.Canje_Insertar(dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // PUT: api/cms/club-vinali/canjes/5
        [HttpPut("canjes/{id:int}")]
        public async Task<IActionResult> Canje_Actualizar(int id, [FromBody] CanjeDto dto)
        {
            var result = await _service.Canje_Actualizar(id, dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // DELETE: api/cms/club-vinali/canjes/5
        [HttpDelete("canjes/{id:int}")]
        public async Task<IActionResult> Canje_Eliminar(int id)
        {
            var result = await _service.Canje_Eliminar(id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // ============================================================
        // NIVELES
        // ============================================================

        // GET: api/cms/club-vinali/niveles?idestado=1
        [HttpGet("niveles")]
        public async Task<IActionResult> Nivel_Listar([FromQuery] int? idestado)
        {
            var data = await _service.Nivel_Listar(idestado);
            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/niveles/5
        [HttpGet("niveles/{id:int}")]
        public async Task<IActionResult> Nivel_Obtener(int id)
        {
            var data = await _service.Nivel_Obtener(id);
            if (data == null)
                return NotFound(ApiResponse<object>.Fail("Nivel no encontrado."));

            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/niveles/por-puntos/1280
        [HttpGet("niveles/por-puntos/{puntos:int}")]
        public async Task<IActionResult> Nivel_PorPuntos(int puntos)
        {
            var data = await _service.Nivel_ObtenerPorPuntos(puntos);
            if (data == null)
                return NotFound(ApiResponse<object>.Fail("No hay nivel para ese puntaje."));

            return Ok(ApiResponse<object>.Ok(data));
        }

        // GET: api/cms/club-vinali/niveles/todos-con-beneficios
        [HttpGet("niveles/todos-con-beneficios")]
        public async Task<IActionResult> Nivel_TodosConBeneficios()
        {
            var data = await _service.Nivel_ObtenerTodosConBeneficios();
            return Ok(ApiResponse<object>.Ok(data));
        }

        // POST: api/cms/club-vinali/niveles
        [HttpPost("niveles")]
        public async Task<IActionResult> Nivel_Insertar([FromBody] NivelDto dto)
        {
            var result = await _service.Nivel_Insertar(dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // PUT: api/cms/club-vinali/niveles/5
        [HttpPut("niveles/{id:int}")]
        public async Task<IActionResult> Nivel_Actualizar(int id, [FromBody] NivelDto dto)
        {
            var result = await _service.Nivel_Actualizar(id, dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        // DELETE: api/cms/club-vinali/niveles/5
        [HttpDelete("niveles/{id:int}")]
        public async Task<IActionResult> Nivel_Eliminar(int id)
        {
            var result = await _service.Nivel_Eliminar(id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}