using Microsoft.AspNetCore.Mvc;
using Projeto_Gamer_ASP.NET_MVC.Infra;
using Projeto_Gamer_ASP.NET_MVC.Models;

namespace Projeto_Gamer_ASP.NET_MVC.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context context = new Context();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogador = context.Jogador.ToList();
            ViewBag.Equipe = context.Equipe.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        // [Route("Cadastrar")]
        // public IActionResult Cadastrar(IFormCollection form) {
        //     Jogador novoJogador = new Jogador();

        //     novoJogador.
        // }
    }
}