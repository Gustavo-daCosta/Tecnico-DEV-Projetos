using Microsoft.AspNetCore.Mvc;
using Projeto_Gamer_ASP.NET_MVC.Infra;
using Projeto_Gamer_ASP.NET_MVC.Models;

namespace Projeto_Gamer_ASP.NET_MVC.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }
        // Instância do objeto da classe Context : Acessa o banco de dados
        Context context = new Context();
                                           //Controller/Action
        [Route("Listar")] // https://localhost/Equipe/Listar
        public IActionResult Index()
        {
            // A ViewBag é uma "bolsa" para guardar instâncias do objeto Equipe, como uma lista
            ViewBag.Equipe = context.Equipe.ToList();
            // Retorna a View de equipe
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public IActionResult Cadastrar(IFormCollection form) {
            Equipe novaEquipe = new Equipe();

            novaEquipe.Nome = form["Nome"].ToString();
            novaEquipe.Imagem = form["Imagem"].ToString();

            context.Equipe.Add(novaEquipe);
            // c.Add(novaEquipe) - Isso também funciona

            context.SaveChanges();

            ViewBag.Equipe = context.Equipe.ToList();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}