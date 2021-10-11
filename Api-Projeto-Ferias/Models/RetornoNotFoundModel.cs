using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api_Projeto_Ferias.Models
{
    public class RetornoNotFoundModel
    {
        public NotFoundObjectResult RetornoNotFound (int id)
        {
            return new NotFoundObjectResult($"Não foi encontrado nenhum registro com o id: {id}");
        }
    }
}
