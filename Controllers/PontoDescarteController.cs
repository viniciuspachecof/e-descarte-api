using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_descarte_api.Data;
using e_descarte_api.Models;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

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
                var result = await _repo.GetAllPontosDescarteAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("ByStatus")]
        public async Task<ActionResult<List<PontoDescarte>>> GetAllPontosDescarteAsyncStatus()
        {
            try
            {
                var result = await _repo.GetAllPontosDescarteAsyncStatus(true);

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
                var result = await _repo.GetPontoDescarteAsyncById(pontodescarteId, true);

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
                var result = await _repo.GetPontoDescarteAsyncByUsuarioId(usuarioId, true);

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
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("NOTIFICAÇÃO E-DESCARTE", "notificacaoedescarteoficial@gmail.com"));
                    message.To.Add(new MailboxAddress("E-DESCARTE", "edescarteoficial@gmail.com"));
                    message.Subject = "Novo ponto de descarte cadastrado!";

                    var usuario = await _repo.GetUsuarioAsyncById(model.usuarioId);

                    if (usuario == null) return NotFound();

                    message.Body = new TextPart("plain")
                    {
                        Text = "Código Ponto descarte: " + model.id + "\nUsuário responsável: " + usuario.nome + "\nEmail do usuário: " + usuario.email + "\nTelefone do usuário: " + usuario.fone + "\nPonto cadastrado: " + model.nome + "\nObs.: Acesse o aplicativo como administrador para a aprovação/reprovação deste ponto de descarte."
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("notificacaoedescarteoficial@gmail.com", "edescarte123");

                        client.Send(message);

                        client.Disconnect(true);
                    }

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
                var pontodescarte = await _repo.GetPontoDescarteAsyncById(pontodescarteId, false);
                if (pontodescarte == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
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
                var pontodescarte = await _repo.GetPontoDescarteAsyncById(pontodescarteId, false);
                if (pontodescarte == null) return NotFound();

                _repo.Delete(pontodescarte);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(new { message = "Deletado" });
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