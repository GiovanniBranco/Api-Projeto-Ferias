using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Data.Dtos;
using Api_Projeto_Ferias.Models;
using AutoMapper;

namespace Api_Projeto_Ferias.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioSaidaDto>();
            CreateMap<Usuario, UsuarioRetornoSemFeriasDto>();
            CreateMap<UsuarioEntradaDto, Usuario>();
        }
    }
}
