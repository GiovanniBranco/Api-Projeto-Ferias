using System.Collections.Generic;

namespace Api_Projeto_Ferias.Data.Dtos
{
    public class SaidaTodosUsuariosDto
    {
        public string UserName { get; set; }
        public IList<ConjuntoFeriasSaidaDto> Ferias { get; set; }
    }
}
