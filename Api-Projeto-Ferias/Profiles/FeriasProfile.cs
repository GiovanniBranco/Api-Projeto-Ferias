using System.Collections.Generic;
using Api_Projeto_Ferias.Data.Dtos;
using Api_Projeto_Ferias.Models;
using AutoMapper;

namespace Api_Projeto_Ferias.Profiles
{
    public class FeriasProfile : Profile
    {
        public FeriasProfile()
        {
            CreateMap<IList<Ferias>, IList<ConjuntoFeriasSaidaDto>>();
            CreateMap<IList<ConjuntoFeriasSaidaDto>, IList<Ferias>>();
        }
    }
}
