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
    public class PontoDescarteController : ControllerBase
    {
        private readonly IRepository _repo;

        public PontoDescarteController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PontoDescarte>>> Get()
        {
            try
            {
                var result = await _repo.GetAllPontosDescarteAsync(true, true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{pontodescarteId}")]
        public async Task<IActionResult> GetByPontoDescarteId(int pontodescarteId)
        {
            try
            {
                var result = await _repo.GetPontoDescarteAsyncById(pontodescarteId, true, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByUsuario/{usuarioId}")]
        public async Task<IActionResult> GetPontoDescarteAsyncByUsuarioId(int usuarioId)
        {
            try
            {
                var result = await _repo.GetPontoDescarteAsyncByUsuarioId(usuarioId, true, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(PontoDescarte model)
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

        [HttpPut("{pontodescarteId}")]
        public async Task<IActionResult> put(int pontodescarteId, PontoDescarte model)
        {
            try
            {
                var pontodescarte = await _repo.GetPontoDescarteAsyncById(pontodescarteId, false, false);
                if(pontodescarte == null) return NotFound();

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

        [HttpDelete("{pontodescarteId}")]
        public async Task<IActionResult> delete(int pontodescarteId)
        {
            try
            {
                var pontodescarte = await _repo.GetPontoDescarteAsyncById(pontodescarteId, false, false);
                if(pontodescarte == null) return NotFound();

                _repo.Delete(pontodescarte);

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