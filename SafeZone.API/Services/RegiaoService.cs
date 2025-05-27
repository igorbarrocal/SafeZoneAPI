using Microsoft.EntityFrameworkCore;
using SafeZoneApi.Data;
using SafeZoneApi.DTOs;
using SafeZoneApi.Models;

namespace SafeZoneApi.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly SafeZoneContext _context;

        public RegiaoService(SafeZoneContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Regiao>> GetAllAsync()
        {
            return await _context.Regioes.ToListAsync();
        }

        public async Task<Regiao?> GetByIdAsync(int id)
        {
            return await _context.Regioes.FindAsync(id);
        }

        public async Task<Regiao> CreateAsync(RegiaoCreateDTO dto)
        {
            var regiao = new Regiao(dto.Nome, dto.Descricao);
            _context.Regioes.Add(regiao);
            await _context.SaveChangesAsync();
            return regiao;
        }

        public async Task<bool> UpdateAsync(int id, RegiaoCreateDTO dto)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
                return false;

            regiao.Update(dto.Nome, dto.Descricao);
            _context.Entry(regiao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
                return false;

            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
