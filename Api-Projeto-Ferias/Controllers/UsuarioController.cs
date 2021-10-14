using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Data;
using Api_Projeto_Ferias.Data.Dtos;
using Api_Projeto_Ferias.Models;
using Api_Projeto_Ferias.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Projeto_Ferias.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly FeriasContext _context;
        private readonly IMapper _mapper;
        private readonly RetornoNotFoundModel _retornoNotFound;
        private readonly VerificaProximasFeriasService _verificaFerias;

        public UsuarioController(FeriasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _retornoNotFound = new RetornoNotFoundModel();
            _verificaFerias = new VerificaProximasFeriasService(context);
        }


        [HttpGet]
        public IActionResult ObterTodos()
        {
            var usuarios = _context.Usuarios;

            var usuariosRetorno = new List<UsuarioRetornoSemFeriasDto>();

            foreach (var item in usuarios)
            {
                usuariosRetorno.Add(_mapper.Map<UsuarioRetornoSemFeriasDto>(item));
            }

            return Ok(usuariosRetorno);
        }


        [HttpGet("ferias")]
        public async Task<IActionResult> ObterTodosComFerias()
        {
            var retorno = new List<SaidaTodosUsuariosDto>();
            var usuarios = await _context.Usuarios.ToListAsync();

            foreach (var usuario in usuarios)
            {
            var ListaFerias = new List<ConjuntoFeriasSaidaDto>();

                var ferias = await _context.Ferias
                .Include(u => u.Usuario)
                .Where(f => f.Usuario.Id == usuario.Id)
                .ToListAsync();

                foreach (var itemFerias in ferias)
                {
                    ListaFerias.Add(new ConjuntoFeriasSaidaDto
                    {
                        DataFimFerias = itemFerias.DataFimFerias,
                        DataInicioFerias = itemFerias.DataInicioFerias,
                    });
                }

                retorno.Add(new SaidaTodosUsuariosDto
                {
                    UserName = usuario.UserName,
                    Ferias = ListaFerias,
                });

            }

            return Ok(retorno);
        }


        [HttpGet("ferias/{id}")]
        public IActionResult ObterPorIdComFerias(int id)
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return _retornoNotFound.RetornoNotFound(id);
            }

            var proximasFerias = _verificaFerias.ObtemFeriasFuturas(usuario);

            if (proximasFerias == null)
            {
                return NoContent();
            }

            var retorno = new UsuarioSaidaDto
            {
                UserName = usuario.UserName,
                DataInicio = proximasFerias.DataInicioFerias,
                DataFim = proximasFerias.DataFimFerias,
                DiasParaProximasFerias = _verificaFerias.CalculaDias(usuario)
            };

            return Ok(retorno);
        }


        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return _retornoNotFound.RetornoNotFound(id);
            }
           
            return Ok(_mapper.Map<UsuarioRetornoSemFeriasDto>(usuario));
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] UsuarioEntradaDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario { UserName = usuarioDto.UserName };
                usuario.Senha = CriptService.GeraSenhaCriptografada(usuario, usuarioDto.Senha);
                usuario.Email = usuarioDto.Email;

                _context.Usuarios.Add(usuario);
                var resultado = await _context.SaveChangesAsync();

                var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.UserName == usuarioDto.UserName);

                return CreatedAtAction(nameof(ObterPorId), new { id = usuarioDb.Id }, usuarioDb);
            }

            return BadRequest();
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UsuarioEntradaUpdateDto usuarioAtualizado)
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return _retornoNotFound.RetornoNotFound(id);
            }


            if (usuarioAtualizado.Email != null )
            {
                usuario.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.UserName != null)
            {
                usuario.UserName = usuarioAtualizado.UserName;
            }

            if (usuarioAtualizado.Senha != null)
            {
                usuario.Senha = CriptService.GeraSenhaCriptografada(usuario, usuarioAtualizado.Senha);
            }

            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return _retornoNotFound.RetornoNotFound(id);
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }


        private Usuario ConsultarUsuarioDb(int id)
        {
            Usuario usuario = _context.Usuarios
                .FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return null;
            }
            else
            {
                return usuario;
            }
        }
    }
}
