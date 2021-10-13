using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Models;

namespace Api_Projeto_Ferias.Data.Dtos
{
    public class FeriasEntradaDto
    {
        [Required]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "É necessário informar a data de ínicio das férias")]
        public DateTime DataInicioFerias { get; set; }

        [Required(ErrorMessage = "É necessário informar a data de fim das férias")]
        public DateTime DataFimFerias { get; set; }
    }
}
