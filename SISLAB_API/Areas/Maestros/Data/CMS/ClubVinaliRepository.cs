using Dapper;
using Microsoft.Data.SqlClient;
using SISLAB_API.Areas.Maestros.Models;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISLAB_API.Areas.Maestros.Repositories
{
    public class ClubVinaliRepository
    {
        private readonly string _connectionString;

        public ClubVinaliRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerQFPHARMA")
                ?? throw new ArgumentNullException(nameof(_connectionString), "La cadena de conexión no está configurada");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        // ============================================================
        // CONTENIDO
        // ============================================================
        public async Task<IEnumerable<Contenido>> Contenido_Listar(string? seccion, int? idEstado)
        {
            using var conn = Connection;
            return await conn.QueryAsync<Contenido>(
                "CMS.sp_ClubVinali_Contenido_Listar",
                new { seccion, idestado = idEstado },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Contenido?> Contenido_Obtener(int idContenido)
        {
            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<Contenido>(
                "CMS.sp_ClubVinali_Contenido_Obtener",
                new { idContenido },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Contenido>> Contenido_ObtenerPorSeccion(string seccion)
        {
            using var conn = Connection;
            return await conn.QueryAsync<Contenido>(
                "CMS.sp_ClubVinali_Contenido_ObtenerPorSeccion",
                new { seccion },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Contenido_Insertar(ContenidoDto dto)
        {
            using var conn = Connection;
            return await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Contenido_Insertar",
                new
                {
                    seccion = dto.Seccion,
                    titulo = dto.Titulo,
                    subtitulo = dto.Subtitulo,
                    descripcion = dto.Descripcion,
                    imagenUrl = dto.ImagenUrl,
                    enlace = dto.Enlace,
                    textoBoton = dto.TextoBoton,
                    extra1 = dto.Extra1,
                    extra2 = dto.Extra2,
                    orden = dto.Orden,
                    idestado = dto.idestado
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> Contenido_Actualizar(int idContenido, ContenidoDto dto)
        {
            using var conn = Connection;
            var resultado = await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Contenido_Actualizar",
                new
                {
                    idContenido,
                    seccion = dto.Seccion,
                    titulo = dto.Titulo,
                    subtitulo = dto.Subtitulo,
                    descripcion = dto.Descripcion,
                    imagenUrl = dto.ImagenUrl,
                    enlace = dto.Enlace,
                    textoBoton = dto.TextoBoton,
                    extra1 = dto.Extra1,
                    extra2 = dto.Extra2,
                    orden = dto.Orden,
                    idestado = dto.idestado
                },
                commandType: CommandType.StoredProcedure);
            return resultado > 0;
        }

        public async Task<bool> Contenido_Eliminar(int idContenido)
        {
            using var conn = Connection;
            var resultado = await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Contenido_Eliminar",
                new { idContenido },
                commandType: CommandType.StoredProcedure);
            return resultado > 0;
        }

        // ============================================================
        // CANJES
        // ============================================================
        public async Task<IEnumerable<Canje>> Canje_Listar(string? tipoCanje, int? idEstado)
        {
            using var conn = Connection;
            return await conn.QueryAsync<Canje>(
                "CMS.sp_ClubVinali_Canjes_Listar",
                new { tipoCanje, idestado = idEstado },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Canje?> Canje_Obtener(int idCanje)
        {
            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<Canje>(
                "CMS.sp_ClubVinali_Canjes_Obtener",
                new { idCanje },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Canje>> Canje_ObtenerPorTipo(string tipoCanje)
        {
            using var conn = Connection;
            return await conn.QueryAsync<Canje>(
                "CMS.sp_ClubVinali_Canjes_ObtenerPorTipo",
                new { tipoCanje },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Canje_Insertar(CanjeDto dto)
        {
            using var conn = Connection;
            return await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Canjes_Insertar",
                new
                {
                    idProducto = dto.IdProducto,
                    tipoCanje = dto.TipoCanje,
                    puntosRequeridos = dto.PuntosRequeridos,
                    imagenUrl = dto.ImagenUrl,
                    descripcion = dto.Descripcion,
                    orden = dto.Orden,
                    idestado = dto.idestado
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> Canje_Actualizar(int idCanje, CanjeDto dto)
        {
            using var conn = Connection;
            var resultado = await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Canjes_Actualizar",
                new
                {
                    idCanje,
                    idProducto = dto.IdProducto,
                    tipoCanje = dto.TipoCanje,
                    puntosRequeridos = dto.PuntosRequeridos,
                    imagenUrl = dto.ImagenUrl,
                    descripcion = dto.Descripcion,
                    orden = dto.Orden,
                    idestado = dto.idestado
                },
                commandType: CommandType.StoredProcedure);
            return resultado > 0;
        }

        public async Task<bool> Canje_Eliminar(int idCanje)
        {
            using var conn = Connection;
            var resultado = await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Canjes_Eliminar",
                new { idCanje },
                commandType: CommandType.StoredProcedure);
            return resultado > 0;
        }

        public async Task<IEnumerable<dynamic>> Canje_BuscarProductos(string? busqueda)
        {
            using var conn = Connection;
            return await conn.QueryAsync(
                "CMS.sp_ClubVinali_BuscarProductos",
                new { busqueda },
                commandType: CommandType.StoredProcedure);
        }

        // ============================================================
        // NIVELES
        // ============================================================
        public async Task<IEnumerable<Nivel>> Nivel_Listar(int? idEstado)
        {
            using var conn = Connection;
            using var multi = await conn.QueryMultipleAsync(
                "CMS.sp_ClubVinali_Niveles_Listar",
                new { idestado = idEstado },
                commandType: CommandType.StoredProcedure);

            var niveles = (await multi.ReadAsync<Nivel>()).ToList();
            var beneficios = (await multi.ReadAsync<NivelBeneficio>()).ToList();

            foreach (var n in niveles)
                n.Beneficios = beneficios.Where(b => b.IdNivel == n.IdNivel).ToList();

            return niveles;
        }

        public async Task<Nivel?> Nivel_Obtener(int idNivel)
        {
            using var conn = Connection;
            using var multi = await conn.QueryMultipleAsync(
                "CMS.sp_ClubVinali_Niveles_Obtener",
                new { idNivel },
                commandType: CommandType.StoredProcedure);

            var nivel = await multi.ReadFirstOrDefaultAsync<Nivel>();
            if (nivel == null) return null;

            nivel.Beneficios = (await multi.ReadAsync<NivelBeneficio>()).ToList();
            return nivel;
        }

        public async Task<Nivel?> Nivel_ObtenerPorPuntos(int puntos)
        {
            using var conn = Connection;
            return await conn.QueryFirstOrDefaultAsync<Nivel>(
                "CMS.sp_ClubVinali_Niveles_ObtenerPorPuntos",
                new { puntos },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Nivel>> Nivel_ObtenerTodosConBeneficios()
        {
            using var conn = Connection;
            using var multi = await conn.QueryMultipleAsync(
                "CMS.sp_ClubVinali_Niveles_ObtenerTodosConBeneficios",
                commandType: CommandType.StoredProcedure);

            var niveles = (await multi.ReadAsync<Nivel>()).ToList();
            var beneficios = (await multi.ReadAsync<NivelBeneficio>()).ToList();

            foreach (var n in niveles)
                n.Beneficios = beneficios.Where(b => b.IdNivel == n.IdNivel).ToList();

            return niveles;
        }

        public async Task<int> Nivel_Insertar(NivelDto dto)
        {
            using var conn = Connection;
            var beneficiosJson = JsonSerializer.Serialize(dto.Beneficios);

            return await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Niveles_Insertar",
                new
                {
                    nombre = dto.Nombre,
                    descripcion = dto.Descripcion,
                    puntosMinimos = dto.PuntosMinimos,
                    puntosMaximos = dto.PuntosMaximos,
                    descuento = dto.Descuento,
                    colorHex = dto.ColorHex,
                    imagenUrl = dto.ImagenUrl,
                    orden = dto.Orden,
                    idestado = dto.IdEstado,
                    beneficios = beneficiosJson
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> Nivel_Actualizar(int idNivel, NivelDto dto)
        {
            using var conn = Connection;
            var beneficiosJson = JsonSerializer.Serialize(dto.Beneficios);

            var resultado = await conn.ExecuteScalarAsync<int>(
                "CMS.sp_ClubVinali_Niveles_Actualizar",
                new
                {
                    idNivel,
                    nombre = dto.Nombre,
                    descripcion = dto.Descripcion,
                    puntosMinimos = dto.PuntosMinimos,
                    puntosMaximos = dto.PuntosMaximos,
                    descuento = dto.Descuento,
                    colorHex = dto.ColorHex,
                    imagenUrl = dto.ImagenUrl,
                    orden = dto.Orden,
                    idestado = dto.IdEstado,
                    beneficios = beneficiosJson
                },
                commandType: CommandType.StoredProcedure);
            return resultado > 0;
        }

        public async Task<bool> Nivel_Eliminar(int idNivel)
        {
            using var conn = Connection;
            var rows = await conn.ExecuteAsync(
                "CMS.sp_ClubVinali_Niveles_Eliminar",
                new { idNivel },
                commandType: CommandType.StoredProcedure);
            return rows > 0;
        }
    }
}