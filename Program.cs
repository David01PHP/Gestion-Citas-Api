using GestionDeCitas.Data;
using GestionDeCitas.Services;
using GestionDeCitas.Services.Citas;
using GestionDeCitas.Services.Especialidades;
using GestionDeCitas.Services.Medicos;
using GestionDeCitas.Services.Pacientes;
using GestionDeCitas.Services.Tratamientos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//controller
builder.Services.AddControllers();
//mysql
builder.Services.AddDbContext<GestionContext>(options => options.UseMySql(
                                builder.Configuration.GetConnectionString("MySqlConnection"),
                                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
                                ));
builder.Services.AddScoped< IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped< ITratamientoRepository, TratamientoRepository>();
builder.Services.AddScoped< IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped< ICitaRepository, CitaRepository>();
builder.Services.AddScoped< IMedicoRepository, MedicoRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
