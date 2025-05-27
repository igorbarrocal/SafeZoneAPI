using Microsoft.EntityFrameworkCore;
using SafeZoneApi.Data;
using SafeZoneApi.Models;
using SafeZoneApi.DTOs;

namespace SafeZoneApi.Services
{
    public class SensorService : ISensorService
    {
        private readonly SafeZoneContext _context;

        public SensorService(SafeZoneContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sensor>> GetAllAsync()
        {
            return await _context.Sensores
                .Include(s => s.Regiao)
                .ToListAsync();
        }

        public async Task<Sensor?> GetByIdAsync(int id)
        {
            return await _context.Sensores
                .Include(s => s.Regiao)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Alterado para receber SensorCreateDTO e criar a entidade internamente
        public async Task<Sensor> CreateAsync(SensorCreateDTO dto)
        {
            var regiao = await _context.Regioes.FindAsync(dto.RegiaoId);
            if (regiao == null)
            {
                throw new Exception("Região não encontrada.");
            }

            var sensor = new Sensor(dto.Tipo, dto.UnidadeMedida, dto.RegiaoId);

            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();

            return sensor;
        }

        public async Task UpdateAsync(Sensor sensor)
        {
            _context.Entry(sensor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensores.Remove(sensor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
