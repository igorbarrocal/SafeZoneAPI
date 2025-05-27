using Microsoft.AspNetCore.Mvc;
using SafeZoneApi.DTOs;
using SafeZoneApi.Models;
using SafeZoneApi.Services;

namespace SafeZoneApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }
        // GET: api/Regiaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegiaoDTO>>> GetAll()
        {
            var regioes = await _regiaoService.GetAllAsync();

            var regioesDto = regioes.Select(r => new RegiaoDTO
            {
                Id = r.Id,
                Nome = r.Nome,
                Descricao = r.Descricao
            });

            return Ok(regioesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegiaoDTO>> GetById(int id)
        {
            var regiao = await _regiaoService.GetByIdAsync(id);
            if (regiao == null)
                return NotFound();

            var regiaoDto = new RegiaoDTO
            {
                Id = regiao.Id,
                Nome = regiao.Nome,
                Descricao = regiao.Descricao
            };

            return Ok(regiaoDto);
        }
        // POST: api/Regiao
        [HttpPost]
        public async Task<ActionResult<RegiaoDTO>> Create(RegiaoCreateDTO regiaoCreateDto)
        {
            var regiao = await _regiaoService.CreateAsync(regiaoCreateDto);

            var regiaoDto = new RegiaoDTO
            {
                Id = regiao.Id,
                Nome = regiao.Nome,
                Descricao = regiao.Descricao
            };

            return CreatedAtAction(nameof(GetById), new { id = regiao.Id }, regiaoDto);
        }
        // PUT: api/Regiao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegiaoCreateDTO regiaoUpdateDto)
        {
            var updated = await _regiaoService.UpdateAsync(id, regiaoUpdateDto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        // DELETE: api/Regiao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _regiaoService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
