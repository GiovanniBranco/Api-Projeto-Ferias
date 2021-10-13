﻿using System;
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

        public UsuarioController(FeriasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _retornoNotFound = new RetornoNotFoundModel();
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_context.Usuarios);
        }


        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return _retornoNotFound.RetornoNotFound(id);
            }

            return Ok(usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] UsuarioEntradaDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario { UserName = usuarioDto.UserName };
                usuario.Senha = CriptService.GeraSenhaCriptografada(usuario, usuarioDto.Senha);

                _context.Usuarios.Add(usuario);
                var resultado = await _context.SaveChangesAsync();

                var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.UserName == usuarioDto.UserName);

                return CreatedAtAction(nameof(ObterPorId), new { id = usuarioDb.Id }, usuarioDb);
            }

            return BadRequest();
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UsuarioEntradaDto usuarioAtualizado)
        {
            Usuario usuario = ConsultarUsuarioDb(id);

            if (usuario == null)
            {
                return _retornoNotFound.RetornoNotFound(id);
            }

            _mapper.Map(usuarioAtualizado, usuario);
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
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);

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
