using System.ComponentModel.DataAnnotations;
using System;

namespace Api_Projeto_Ferias.Profiles
{
    public class FeriasSaidaDto
    {
        public string Usuario { get; set; }
        public DateTime DataInicioFerias { get; set; }
        public DateTime DataFimFerias { get; set; }
    }
}