using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Models
{
    [Table("ferias")]
    public class Ferias
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("usuario_Id")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage ="É necessário informar a data de ínicio das férias")]
        public DateTime DataInicioFerias { get; set; }

        [Required(ErrorMessage = "É necessário informar a data de fim das férias")]
        public DateTime DataFimFerias { get; set; }
    }
}
