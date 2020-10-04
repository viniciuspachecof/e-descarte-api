using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e_descarte_api.Data;
using e_descarte_api.Models;
using e_descarte_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace e_descarte_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IRepository _repo;

        public LoginController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]       
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            var usuario = await _repo.GetUsuarioAsyncByNamePassword(model.email, model.senha);

            if (usuario == null)
                return NotFound(new {message = "Email ou senha inválidos"});

            var token = TokenServices.GenerateToken(usuario);
            usuario.senha = "";
            return new{
                usuario = usuario,
                token = token
            };
            
        }
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]

        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]

        public string Authenticated() => String.Format("Autenticado - {0}",User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]

        public string Employee() => "Funcionario";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]

        public string Manager() => "Gerente";

    }
}