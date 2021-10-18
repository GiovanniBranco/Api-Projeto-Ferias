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
        private readonly SignInManager<Usuario> _signInManager;

        public LoginController(FeriasContext context, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel usuario)
        {
            if (ModelState.IsValid)
            {
                var logado = _context.Usuarios.FirstOrDefault(u => u.UserName == usuario.UserName);

                if (logado == null)
                    return new UnauthorizedObjectResult($"Usuário ou senha inválidos");


                var resultado = await _signInManager.CheckPasswordSignInAsync(logado, usuario.Senha, false);

                if (resultado.Succeeded)
                {
                    var token = TokenService.GeradorToken(logado);

                    return Ok(new RetornoLogin(usuario.UserName, token, DateTime.Now));
                }

                return Unauthorized("Usuário ou senha inválidos!");
            }

            return new BadRequestObjectResult($"É necessário informar usuário e senha para fazer o login!");
        }
    }
}
