using Gandalf.MVCWebApp.Dto;
using Gandalf.MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gandalf.MVCWebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqldbProjeto4Context _context;

        public HomeController(ILogger<HomeController> logger, SqldbProjeto4Context context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var produtoSeman = ObterProdutoDaSemana();
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

        //           .Where(dv => dv.DataCriacao >= DateTime.Now.Date.AddDays(-7))

        public ProdutoSemanaDto ObterProdutoDaSemana()
        {
            var result = new ProdutoSemanaDto();
            var produtoMaisVendido = _context.DetalhesVendas     
                .GroupBy(r => r.ProdutoId)
                .OrderBy(x => x.Key)
                .Select(x => new {
                    ProdutoId = x.Key,
                    QuantidadeVendida = x.Sum(y => y.Quantidade)
                }
                )
                .OrderBy(z => z.QuantidadeVendida)
                .FirstOrDefault();

            if (produtoMaisVendido != null)
            {
                var produto = _context.Produtoes.FirstOrDefault(x => x.Id == produtoMaisVendido.ProdutoId);
                result.Nome = produto.Nome;
                result.PrecoUnitario = produto.PrecoUnitario;

                result.QuantidadeVendida = produtoMaisVendido.QuantidadeVendida;                
            }

            return result;
        }
    }
}