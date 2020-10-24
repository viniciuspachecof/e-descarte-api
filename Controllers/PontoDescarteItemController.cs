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
    public class PontoDescarteItemController : ControllerBase
    {
        private readonly IRepository _repo;

        public PontoDescarteItemController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PontoDescarteItem>>> Get()
        {
            try
            {
                var result = await _repo.GetAllPontoDescarteItensAsync(true, true, true, true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{pontodescarteitemId}")]
        public async Task<IActionResult> GetByPontoDescarteItemId(int pontodescarteitemId)
        {
            try
            {
                var result = await _repo.GetPontoDescarteItemAsyncById(pontodescarteitemId, true, true, true, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByPontoDescarte/{pontodescarteId}")]
        public async Task<IActionResult> GetPontoDescarteItensAsyncByPontoDescarteId(int pontodescarteId)
        {
            try
            {
                var result = await _repo.GetPontoDescarteItensAsyncByPontoDescarteId(pontodescarteId, true, true, true, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByPontoDescarteUsuario/{pontodescarteId}/{usuarioId}")]
        public async Task<IActionResult> GetPontoDescarteItensAsyncByPontoDescarteUsuarioId(int pontodescarteId, int usuarioId)
        {
            try
            {
                var result = await _repo.GetPontoDescarteItensAsyncByPontoDescarteUsuarioId(pontodescarteId, usuarioId, true, true, true, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByPontoDescarteUsuarioNome/{pontodescarteId}/{usuarioNome}")]
        public async Task<IActionResult> GetPontoDescarteItensAsyncByPontoDescarteUsuarioNome(int pontodescarteId, string usuarioNome)
        {
            try
            {
                var result = await _repo.GetPontoDescarteItensAsyncByPontoDescarteUsuarioNome(pontodescarteId, usuarioNome, true, true, true, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByUsuarioTotalPonto/{usuarioId}")]
        public async Task<IActionResult> GetPontoDescarteItensAsyncByUsuarioIdTotalPonto(int usuarioId)
        {
            try
            {
                var result = await _repo.GetPontoDescarteItensAsyncByUsuarioIdTotalPonto(usuarioId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }  

        [HttpPost]
        public async Task<IActionResult> post(PontoDescarteItem model)
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
               
        [HttpPut("{pontodescarteitemId}")]
        public async Task<IActionResult> put(int pontodescarteitemId, PontoDescarteItem model)
        {
            try
            {
                var pontodescarteitem = await _repo.GetPontoDescarteItemAsyncById(pontodescarteitemId, false, false, false, false);
                if(pontodescarteitem == null) return NotFound();

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

        [HttpDelete("{pontodescarteitemId}")]
        public async Task<IActionResult> delete(int pontodescarteitemId)
        {
            try
            {
                var pontodescarteitem = await _repo.GetPontoDescarteItemAsyncById(pontodescarteitemId, false, false, false, false);
                if(pontodescarteitem == null) return NotFound();

                _repo.Delete(pontodescarteitem);

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