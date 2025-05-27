using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SafeZoneApi.Data;          
using SafeZoneApi.Services;      

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SafeZoneContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();         
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SafeZone API",
        Version = "v1",
        Description = "API de "
    });
});


builder.Services.AddScoped<IRegiaoService, RegiaoService>();
builder.Services.AddScoped<ISensorService, SensorService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SafeZone API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();       
app.UseAuthorization();

app.MapControllers();
app.Run();
