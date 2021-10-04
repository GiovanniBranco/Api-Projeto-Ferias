using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Data.Dtos
{
    public class UsuarioSaidaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [Range(8, 40, ErrorMessage = "O email deve conter de 8 a 40 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        [Range(8, 16, ErrorMessage = "A senha deve conter de 8 a 40 caracteres")]
        public string Senha { get; set; }
    }
}
