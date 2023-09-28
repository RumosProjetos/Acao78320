using Gandalf.MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gandalf.MVCWebApp.Controllers
{
    public class ProdutoSemanaDto
    {
        public string? Nome { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotalVendido => PrecoUnitario * QuantidadeVendida;
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var produtoSeman = new ProdutoSemanaDto
            {
                Nome = "Espada",
                PrecoUnitario = 1000M,
                QuantidadeVendida = 10
            };

            ViewBag.ProdutoSemana = produtoSeman;

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