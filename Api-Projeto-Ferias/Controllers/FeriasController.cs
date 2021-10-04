using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api_Projeto_Ferias.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FeriasController : Controller
    {
        public IActionResult ObterTodos()
        {
            return Ok();
        }
    }
}
