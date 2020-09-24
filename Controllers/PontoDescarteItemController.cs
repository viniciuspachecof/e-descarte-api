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
                var result = await _repo.GetAllPontoDescarteItensAsync(true, true);

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
                var result = await _repo.GetPontoDescarteItemAsyncById(pontodescarteitemId, true, true);
                
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
                var pontodescarteitem = await _repo.GetPontoDescarteItemAsyncById(pontodescarteitemId, false, false);
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
                var PontoDescarteItem = await _repo.GetPontoDescarteItemAsyncById(pontodescarteitemId, false, false);
                if(PontoDescarteItem == null) return NotFound();

                _repo.Delete(PontoDescarteItem);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
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