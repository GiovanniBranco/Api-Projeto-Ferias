using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Data.Dtos
{
    public class UsuarioEntradaDto
    {
        [Required(ErrorMessage = "O usuario é obrigatório")]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
