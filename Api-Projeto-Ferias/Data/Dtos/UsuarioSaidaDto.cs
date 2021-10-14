using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Data.Dtos
{
    public class UsuarioSaidaDto
    {
        public string UserName { get; set; }
        public int DiasParaProximasFerias { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
