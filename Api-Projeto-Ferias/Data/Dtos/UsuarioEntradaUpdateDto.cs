using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Data.Dtos
{
    public class UsuarioEntradaUpdateDto
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(dataType:DataType.Password)]
        public string Senha { get; set; }
    }
}
