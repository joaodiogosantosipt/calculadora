using calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]  // este anotador é facultativo
        public IActionResult Index()
        {

            // preparar os dados a serem enviados para a View na primeira interação
            ViewBag.Visor = "0";

            return View();
        }


        [HttpPost] // só qd o formulário for submetido em 'post' ele será acionado
        public IActionResult Index(
           string botao,
           string visor,
           string primeiroOperando,
           string operador
           )
        {

            // testar valor do 'botao'
            switch (botao)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    // pressionei um algarismo
                    if (visor == "0") { visor = botao; }
                    else { visor = visor + botao; }
                    // desafio: fazer em modo algébrico esta operação...
                    break;

                case ",":
                    // foi pressionado ','
                    if (!visor.Contains(',')) visor += ',';
                    break;

                case "+/-":
                    // vamos inverter o valor do 'visor'
                    if (visor.StartsWith('-')) visor = visor.Substring(1);
                    else visor = '-' + visor;
                    // sugestao: fazer de forma algebrica
                    break;

                case "+":
                case "-":
                case "x":
                case ":":
                    // foi pressionado um operador
                    primeiroOperando = visor;
                    operador = botao;

                    break;

            }

            // preparar dados para serem enviados à View
            ViewBag.Visor = visor;
            ViewBag.PrimeiroOperando = primeiroOperando;
            ViewBag.Operador = operador;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}