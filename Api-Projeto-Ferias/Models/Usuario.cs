using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Api_Projeto_Ferias.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [JsonIgnore]
        public string Hash { get; set; }

        [Required]
        [JsonIgnore]
        public string Salt { get; set; }

        public IList<Ferias> ferias;

        public Usuario()
        {
            this.ferias = new List<Ferias>();
        }
    }
}
