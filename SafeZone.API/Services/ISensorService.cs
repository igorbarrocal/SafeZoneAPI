using SafeZoneApi.Models;
using SafeZoneApi.DTOs;

namespace SafeZoneApi.Services
{
    public interface ISensorService
    {
        Task<IEnumerable<Sensor>> GetAllAsync();
        Task<Sensor?> GetByIdAsync(int id);

        // Agora CreateAsync recebe SensorCreateDTO
        Task<Sensor> CreateAsync(SensorCreateDTO dto);

        Task UpdateAsync(Sensor sensor);
        Task DeleteAsync(int id);
    }
}
