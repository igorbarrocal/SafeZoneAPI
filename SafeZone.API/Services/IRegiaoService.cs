using SafeZoneApi.DTOs;
using SafeZoneApi.Models;

namespace SafeZoneApi.Services
{
    public interface IRegiaoService
    {
        Task<IEnumerable<Regiao>> GetAllAsync();
        Task<Regiao?> GetByIdAsync(int id);
        Task<Regiao> CreateAsync(RegiaoCreateDTO dto);
        Task<bool> UpdateAsync(int id, RegiaoCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
