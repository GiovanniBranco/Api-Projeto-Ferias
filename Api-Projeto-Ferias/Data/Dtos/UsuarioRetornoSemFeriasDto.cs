using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Data.Dtos
{
    public class UsuarioRetornoSemFeriasDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string DataCadastro { get; private set; }
    }
}
