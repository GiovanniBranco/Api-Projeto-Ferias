using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Data;
using Api_Projeto_Ferias.Data.Dtos;
using Api_Projeto_Ferias.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Projeto_Ferias.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioContext _context;
        private readonly IMapper _mapper;

        public UsuarioController( UsuarioContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_context.DbSetUsuario);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId( int id )
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Adicionar( [FromBody] UsuarioEntradaDto usuarioDto )
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            _context.DbSetUsuario.Add(usuario);

            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar( int id, UsuarioEntradaDto usuarioAtualizado )
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _mapper.Map(usuarioAtualizado, usuario);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id )
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if(usuario == null)
            {
                return NotFound();
            }

            _context.DbSetUsuario.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }

        private Usuario ConsultarUsuarioDb(int id)
        {
            Usuario usuario = _context.DbSetUsuario.FirstOrDefault(u => u.Id == id);

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
