using SISLAB_API.Areas.Maestros.Models;
using SISLAB_API.Areas.Maestros.Repositories;

namespace SISLAB_API.Areas.Maestros.Services
{
    public class ClubVinaliService
    {
        private readonly ClubVinaliRepository _repo;

        public ClubVinaliService(ClubVinaliRepository repo)
        {
            _repo = repo;
        }

        // ============================================================
        // CONTENIDO
        // ============================================================
        public Task<IEnumerable<Contenido>> Contenido_Listar(string? seccion, int? idEstado)
            => _repo.Contenido_Listar(seccion, idEstado);

        public Task<Contenido?> Contenido_Obtener(int id)
            => _repo.Contenido_Obtener(id);

        public Task<IEnumerable<Contenido>> Contenido_ObtenerPorSeccion(string seccion)
            => _repo.Contenido_ObtenerPorSeccion(seccion);

        public async Task<ApiResponse<int>> Contenido_Insertar(ContenidoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Seccion))
                return ApiResponse<int>.Fail("La sección es obligatoria.");

            var id = await _repo.Contenido_Insertar(dto);
            return ApiResponse<int>.Ok(id, "Contenido creado correctamente.");
        }

        public async Task<ApiResponse<bool>> Contenido_Actualizar(int id, ContenidoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Seccion))
                return ApiResponse<bool>.Fail("La sección es obligatoria.");

            var ok = await _repo.Contenido_Actualizar(id, dto);
            return ok
                ? ApiResponse<bool>.Ok(true, "Contenido actualizado correctamente.")
                : ApiResponse<bool>.Fail("No se encontró el contenido.");
        }

        public async Task<ApiResponse<bool>> Contenido_Eliminar(int id)
        {
            var ok = await _repo.Contenido_Eliminar(id);
            return ok
                ? ApiResponse<bool>.Ok(true, "Contenido eliminado correctamente.")
                : ApiResponse<bool>.Fail("No se encontró el contenido.");
        }

        // ============================================================
        // CANJES
        // ============================================================
        public Task<IEnumerable<Canje>> Canje_Listar(string? tipo, int? idEstado)
            => _repo.Canje_Listar(tipo, idEstado);

        public Task<Canje?> Canje_Obtener(int id)
            => _repo.Canje_Obtener(id);

        public Task<IEnumerable<Canje>> Canje_ObtenerPorTipo(string tipo)
            => _repo.Canje_ObtenerPorTipo(tipo);

        public Task<IEnumerable<dynamic>> Canje_BuscarProductos(string? busqueda)
            => _repo.Canje_BuscarProductos(busqueda);

        public async Task<ApiResponse<int>> Canje_Insertar(CanjeDto dto)
        {
            if (dto.IdProducto <= 0)
                return ApiResponse<int>.Fail("Debe seleccionar un producto válido.");

            if (string.IsNullOrWhiteSpace(dto.TipoCanje))
                return ApiResponse<int>.Fail("El tipo de canje es obligatorio.");

            if (dto.PuntosRequeridos <= 0)
                return ApiResponse<int>.Fail("Los puntos requeridos deben ser mayores a 0.");

            var id = await _repo.Canje_Insertar(dto);
            return ApiResponse<int>.Ok(id, "Canje creado correctamente.");
        }

        public async Task<ApiResponse<bool>> Canje_Actualizar(int id, CanjeDto dto)
        {
            if (dto.IdProducto <= 0)
                return ApiResponse<bool>.Fail("Debe seleccionar un producto válido.");

            if (string.IsNullOrWhiteSpace(dto.TipoCanje))
                return ApiResponse<bool>.Fail("El tipo de canje es obligatorio.");

            if (dto.PuntosRequeridos <= 0)
                return ApiResponse<bool>.Fail("Los puntos requeridos deben ser mayores a 0.");

            var ok = await _repo.Canje_Actualizar(id, dto);
            return ok
                ? ApiResponse<bool>.Ok(true, "Canje actualizado correctamente.")
                : ApiResponse<bool>.Fail("No se encontró el canje.");
        }

        public async Task<ApiResponse<bool>> Canje_Eliminar(int id)
        {
            var ok = await _repo.Canje_Eliminar(id);
            return ok
                ? ApiResponse<bool>.Ok(true, "Canje eliminado correctamente.")
                : ApiResponse<bool>.Fail("No se encontró el canje.");
        }

        // ============================================================
        // NIVELES
        // ============================================================
        public Task<IEnumerable<Nivel>> Nivel_Listar(int? idEstado)
            => _repo.Nivel_Listar(idEstado);

        public Task<Nivel?> Nivel_Obtener(int id)
            => _repo.Nivel_Obtener(id);

        public Task<Nivel?> Nivel_ObtenerPorPuntos(int puntos)
            => _repo.Nivel_ObtenerPorPuntos(puntos);

        public Task<IEnumerable<Nivel>> Nivel_ObtenerTodosConBeneficios()
            => _repo.Nivel_ObtenerTodosConBeneficios();

        public async Task<ApiResponse<int>> Nivel_Insertar(NivelDto dto)
        {
            var validacion = ValidarNivel(dto);
            if (validacion != null)
                return ApiResponse<int>.Fail(validacion);

            var id = await _repo.Nivel_Insertar(dto);
            return ApiResponse<int>.Ok(id, "Nivel creado correctamente.");
        }

        public async Task<ApiResponse<bool>> Nivel_Actualizar(int id, NivelDto dto)
        {
            var validacion = ValidarNivel(dto);
            if (validacion != null)
                return ApiResponse<bool>.Fail(validacion);

            var ok = await _repo.Nivel_Actualizar(id, dto);
            return ok
                ? ApiResponse<bool>.Ok(true, "Nivel actualizado correctamente.")
                : ApiResponse<bool>.Fail("No se encontró el nivel.");
        }

        public async Task<ApiResponse<bool>> Nivel_Eliminar(int id)
        {
            var ok = await _repo.Nivel_Eliminar(id);
            return ok
                ? ApiResponse<bool>.Ok(true, "Nivel eliminado correctamente.")
                : ApiResponse<bool>.Fail("No se encontró el nivel.");
        }

        // ============================================================
        // VALIDACIONES
        // ============================================================
        private static string? ValidarNivel(NivelDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                return "El nombre del nivel es obligatorio.";

            if (dto.PuntosMinimos < 0)
                return "Los puntos mínimos deben ser mayores o iguales a 0.";

            if (dto.PuntosMaximos.HasValue && dto.PuntosMaximos <= dto.PuntosMinimos)
                return "Los puntos máximos deben ser mayores a los puntos mínimos.";

            if (dto.Descuento.HasValue && (dto.Descuento < 0 || dto.Descuento > 100))
                return "El descuento debe estar entre 0 y 100.";

            return null;
        }
    }
}