using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Projeto_Ferias.Models
{
    public class RetornoLogin
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public DateTime DataeHora { get; set; }

        public RetornoLogin(string login, string token, DateTime dataeHora)
        {
            Login = login;
            Token = token;
            DataeHora = dataeHora;
        }
    }
}
