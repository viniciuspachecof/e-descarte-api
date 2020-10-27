using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_descarte_api.Data;
using e_descarte_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_descarte_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingPontuacaoController : ControllerBase
    {
        private readonly IRepository _repo;

        public RankingPontuacaoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<RankingPontuacao>>> Get()
        {
            try
            {
                var result = await _repo.GetAllRankingPontuacaoAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{rankingpontuacaoId}")]
        public async Task<IActionResult> GetByRankingPontuacaoId(int rankingpontuacaoId)
        {
            try
            {
                var result = await _repo.GetRankingPontuacaoAsyncById(rankingpontuacaoId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByUsuario/{usuarioId}")]
        public async Task<IActionResult> GetRankingPontuacaoAsyncByUsuarioId(int usuarioId)
        {
            try
            {
                var result = await _repo.GetRankingPontuacaoAsyncByUsuarioId(usuarioId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(RankingPontuacao model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);              
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:  {ex.Message}");
            }

            return BadRequest();
        }
               
        [HttpPut("{rankingpontuacaoId}")]
        public async Task<IActionResult> put(int rankingpontuacaoId, RankingPontuacao model)
        {
            try
            {
                var rankingpontuacao = await _repo.GetRankingPontuacaoAsyncById(rankingpontuacaoId, false);
                if(rankingpontuacao == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{rankingpontuacaoId}")]
        public async Task<IActionResult> delete(int rankingpontuacaoId)
        {
            try
            {
                var rankingpontuacao = await _repo.GetRankingPontuacaoAsyncById(rankingpontuacaoId, false);
                if(rankingpontuacao == null) return NotFound();

                _repo.Delete(rankingpontuacao);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok( new { message = "Deletado"});
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}