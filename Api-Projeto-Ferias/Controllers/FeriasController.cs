using System.Collections.Generic;
using System.Linq;
using Api_Projeto_Ferias.Data;
using Api_Projeto_Ferias.Data.Dtos;
using Api_Projeto_Ferias.Models;
using Api_Projeto_Ferias.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Projeto_Ferias.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FeriasController : ControllerBase
    {
        private readonly FeriasContext _context;

        public FeriasController(FeriasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_context.Ferias);
        }

        [HttpGet("{username}")]
        public IActionResult ObterPorUsuario(string username)
        {
            var usuario = EncontrarUsuario(username);

            if (usuario != null)
            {
                var ferias = _context.Ferias
                    .Include(u => u.Usuario)
                    .Where(u => u.Usuario.UserName == username);

                return Ok(ConverteRetornoFerias(ferias));
            }

            return new NotFoundObjectResult($"Não foi encontrado nenhum usuário com username {username}");
        }

        

        [HttpPost]
        public IActionResult Adicionar([FromBody] FeriasEntradaDto ferias)
        {

            var feriasModel = new Ferias();
            feriasModel.DataFimFerias = ferias.DataFimFerias;
            feriasModel.DataInicioFerias = ferias.DataInicioFerias;
            feriasModel.Usuario = EncontrarUsuario(ferias.Usuario);


            if (feriasModel.Usuario == null)
            {
                return new BadRequestObjectResult($"O usuário {ferias.Usuario} não foi encontrado");
            }


            _context.Ferias.Add(feriasModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorUsuario), new { username = feriasModel.Usuario.UserName }, ferias);
        }

        private Usuario EncontrarUsuario(string username)
        {
            var todosUsuario = _context.Usuarios;
            return _context.Usuarios.FirstOrDefault(u => u.UserName == username);
        }

        private static IList<FeriasSaidaDto> ConverteRetornoFerias(IQueryable<Ferias> ferias)
        {
            IList<FeriasSaidaDto> feriasRetorno = new List<FeriasSaidaDto>();
            foreach (var item in ferias)
            {
                var retorno = new FeriasSaidaDto
                {
                    DataFimFerias = item.DataFimFerias,
                    DataInicioFerias = item.DataInicioFerias,
                    Usuario = item.Usuario.UserName
                };

                feriasRetorno.Add(retorno);
            }

            return feriasRetorno;
        }
    }
}
