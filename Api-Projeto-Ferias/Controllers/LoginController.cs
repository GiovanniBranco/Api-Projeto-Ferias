using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Data;
using Api_Projeto_Ferias.Models;
using Api_Projeto_Ferias.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Projeto_Ferias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly FeriasContext _context;

        public LoginController(FeriasContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(LoginModel usuario)
        {
            if (ModelState.IsValid)
            {
                var logado = _context.Usuarios.FirstOrDefault(u => u.UserName == usuario.UserName );
                var resultado = CriptService.ComparaSenhas(usuario.Senha, logado.Hash, logado.Salt);

                if (resultado)
                {
                    var token = TokenService.GeradorToken(logado);

                    return Ok(new RetornoLogin(usuario.UserName, token, DateTime.Now));
                }

                return Unauthorized("Usuário ou senha inválidos!");
            }

            return BadRequest();
        }
    }
}
