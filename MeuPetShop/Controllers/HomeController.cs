using Cadastro_de_pessoas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult ListaDePessoas()
        //{
        //    return View();
        //}

        public IActionResult Privacidade()
        {
            return View();
        }
        [Route("erro/{id}")]
        public IActionResult Error(int id)
        
        
        {
            var modelErro = new ErrorViewModel();

            if(id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! tente novamente mais tardde ou contate nosso suporte";
                modelErro.Titulo = "Ocorreu um erro";
                modelErro.Errocode = id;
            }

            if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe!<br /> Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops!Página não encontrada";
                modelErro.Errocode = id;
            }
            if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permisssão para fazer isto";
                modelErro.Titulo = "Acesso Negado";
                modelErro.Errocode = id;
            }

            return View("Error",modelErro);

        }
    }
}
