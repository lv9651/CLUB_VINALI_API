using Microsoft.AspNetCore.Http.Features;
using Microsoft.Data.SqlClient;
using SISLAB_API.Areas.Maestros.Repositories;
using SISLAB_API.Areas.Maestros.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Kestrel (límite de archivos 3GB)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 3L * 1024 * 1024 * 1024;
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 3L * 1024 * 1024 * 1024;
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:3001", "https://vinaliclub.vinali.pe")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
});

// 🔹 Inyección de dependencias (sin interfaces)
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<PuntajeRepositorio>();
builder.Services.AddScoped<PuntajeServicio>();
builder.Services.AddScoped<ClubVinaliRepository>();
builder.Services.AddScoped<ClubVinaliService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la política CORS (antes de Authorization)
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();