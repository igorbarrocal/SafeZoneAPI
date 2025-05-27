using Microsoft.AspNetCore.Mvc;
using SafeZoneApi.DTOs;
using SafeZoneApi.Models;
using SafeZoneApi.Services;

namespace SafeZoneApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // GET: api/Sensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorDTO>>> GetAll()
        {
            var sensores = await _sensorService.GetAllAsync();

            var sensoresDto = sensores.Select(s => new SensorDTO
            {
                Id = s.Id,
                Tipo = s.Tipo,
                UnidadeMedida = s.UnidadeMedida,
                RegiaoId = s.RegiaoId
            });

            return Ok(sensoresDto);
        }

        // GET: api/Sensor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorDTO>> GetById(int id)
        {
            var sensor = await _sensorService.GetByIdAsync(id);

            if (sensor == null)
                return NotFound();

            var sensorDto = new SensorDTO
            {
                Id = sensor.Id,
                Tipo = sensor.Tipo,
                UnidadeMedida = sensor.UnidadeMedida,
                RegiaoId = sensor.RegiaoId
            };

            return Ok(sensorDto);
        }

        // POST: api/Sensor
        [HttpPost]
        public async Task<ActionResult<SensorDTO>> Create(SensorCreateDTO sensorCreateDto)
        {
            var sensor = await _sensorService.CreateAsync(sensorCreateDto);

            var sensorDto = new SensorDTO
            {
                Id = sensor.Id,
                Tipo = sensor.Tipo,
                UnidadeMedida = sensor.UnidadeMedida,
                RegiaoId = sensor.RegiaoId
            };

            return CreatedAtAction(nameof(GetById), new { id = sensor.Id }, sensorDto);
        }

        // PUT: api/Sensor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SensorCreateDTO sensorUpdateDto)
        {
            var existing = await _sensorService.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.Tipo = sensorUpdateDto.Tipo;
            existing.UnidadeMedida = sensorUpdateDto.UnidadeMedida;
            existing.RegiaoId = sensorUpdateDto.RegiaoId;

            await _sensorService.UpdateAsync(existing);

            return NoContent();
        }

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _sensorService.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await _sensorService.DeleteAsync(id);

            return NoContent();
        }
    }
}
