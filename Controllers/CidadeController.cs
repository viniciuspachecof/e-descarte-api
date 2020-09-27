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
    public class CidadeController : ControllerBase
    {
        private readonly IRepository _repo;

        public CidadeController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cidade>>> Get()
        {
            try
            {
                var result = await _repo.GetAllCidadesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{cidadeId}")]
        public async Task<IActionResult> GetByCidadeId(int cidadeId)
        {
            try
            {
                var result = await _repo.GetCidadeAsyncById(cidadeId);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Cidade model)
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

        [HttpPut("{cidadeId}")]
        public async Task<IActionResult> put(int cidadeId, Cidade model)
        {
            try
            {
                var cidade = await _repo.GetCidadeAsyncById(cidadeId);
                if(cidade == null) return NotFound();

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

        [HttpDelete("{cidadeId}")]
        public async Task<IActionResult> delete(int cidadeId)
        {
            try
            {
                var Cidade = await _repo.GetCidadeAsyncById(cidadeId);
                if(Cidade == null) return NotFound();

                _repo.Delete(Cidade);

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