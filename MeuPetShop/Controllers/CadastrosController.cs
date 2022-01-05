using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Controllers
{
    [Authorize]
    public class CadastrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
