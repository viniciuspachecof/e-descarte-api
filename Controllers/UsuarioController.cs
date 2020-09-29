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
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repo;

        public UsuarioController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                var result = await _repo.GetAllUsuariosAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int usuarioId)
        {
            try
            {
                var result = await _repo.GetUsuarioAsyncById(usuarioId);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Usuario model)
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

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> put(int usuarioId, Usuario model)
        {
            try
            {
                var usuario = await _repo.GetUsuarioAsyncById(usuarioId);
                if(usuario == null) return NotFound();

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

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> delete(int usuarioId)
        {
            try
            {
                var usuario = await _repo.GetUsuarioAsyncById(usuarioId);
                if(usuario == null) return NotFound();

                _repo.Delete(usuario);

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