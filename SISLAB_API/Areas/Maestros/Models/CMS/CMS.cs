namespace SISLAB_API.Areas.Maestros.Models
{
    public class Contenido
    {
        public int IdContenido { get; set; }
        public string Seccion { get; set; } = string.Empty;
        public string? Titulo { get; set; }
        public string? Subtitulo { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Enlace { get; set; }
        public string? TextoBoton { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public int Orden { get; set; }
        public int idestado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    // ==================== CANJES ====================
    public class Canje
    {
        public int IdCanje { get; set; }
        public int IdProducto { get; set; }
        public string? CodigoProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string TipoCanje { get; set; } = string.Empty;
        public int PuntosRequeridos { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Descripcion { get; set; }
        public int Orden { get; set; }
        public int idestado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    // ==================== NIVELES ====================
    public class Nivel
    {
        public int IdNivel { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int PuntosMinimos { get; set; }
        public int? PuntosMaximos { get; set; }
        public decimal? Descuento { get; set; }
        public string? ColorHex { get; set; }
        public string? ImagenUrl { get; set; }
        public int Orden { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<NivelBeneficio> Beneficios { get; set; } = new();
    }

    public class NivelBeneficio
    {
        public int IdBeneficio { get; set; }
        public int IdNivel { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string? Icono { get; set; }
        public int Orden { get; set; }
    }
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "OK")
            => new() { Success = true, Message = message, Data = data };

        public static ApiResponse<T> Fail(string message)
            => new() { Success = false, Message = message, Data = default };
    }

    // ==================== CONTENIDO ====================
    public class ContenidoDto
    {
        public string Seccion { get; set; } = string.Empty;
        public string? Titulo { get; set; }
        public string? Subtitulo { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Enlace { get; set; }
        public string? TextoBoton { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public int Orden { get; set; } = 0;
        public int idestado { get; set; } = 1;
    }

    // ==================== CANJE ====================
    public class CanjeDto
    {
        public int IdProducto { get; set; }
        public string TipoCanje { get; set; } = string.Empty;
        public int PuntosRequeridos { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Descripcion { get; set; }
        public int Orden { get; set; } = 0;
        public int idestado { get; set; } = 1;
    }

    // ==================== NIVEL ====================
    public class NivelDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int PuntosMinimos { get; set; }
        public int? PuntosMaximos { get; set; }
        public decimal? Descuento { get; set; }
        public string? ColorHex { get; set; }
        public string? ImagenUrl { get; set; }
        public int Orden { get; set; } = 0;
        public int IdEstado { get; set; } = 1;
        public List<BeneficioDto> Beneficios { get; set; } = new();
    }

    public class BeneficioDto
    {
        public string Descripcion { get; set; } = string.Empty;
        public string? Icono { get; set; }
        public int Orden { get; set; } = 0;
    }
}