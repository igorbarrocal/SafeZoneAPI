using Microsoft.EntityFrameworkCore;
using SafeZoneApi.Data;
using SafeZoneApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner:

// Conex�o com o banco de dados Oracle (ajuste sua connection string no appsettings.json)
builder.Services.AddDbContext<SafeZoneContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

// Registra os servi�os
builder.Services.AddScoped<IRegiaoService, RegiaoService>();
builder.Services.AddScoped<ISensorService, SensorService>();

// Adiciona Controllers (essencial)
builder.Services.AddControllers();

// Adiciona autoriza��o (porque usar� UseAuthorization)
builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (libera tudo para facilitar consumo externo)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Pipeline HTTP:
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

