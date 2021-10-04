using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Models
{
    public class Ferias
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Usuario_Id")]
        public Usuario Usuario { get; set; }

        [Required]
        public DateTime DataAtual { get; set; }
        
        [Required]
        public DateTime DataInicioFerias { get; set; }
        
        [Required]
        public DateTime DataFimFerias { get; set; }
    }
}
