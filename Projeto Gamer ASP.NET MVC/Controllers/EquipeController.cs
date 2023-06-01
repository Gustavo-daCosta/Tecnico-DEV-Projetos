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

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form) {
            Equipe novaEquipe = new Equipe();

            novaEquipe.Nome = form["Nome"].ToString();
            novaEquipe.Imagem = form["Imagem"].ToString();

            if (string.IsNullOrEmpty(novaEquipe.Nome.Trim())) {
                return LocalRedirect("~/Equipe/Listar");
            }

            // Aqui começa a lógica do upload de imagem
            if (form.Files.Any()) {
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create)) {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            

            context.Equipe.Add(novaEquipe);
            // c.Add(novaEquipe) - Isso também funciona

            context.SaveChanges();

            ViewBag.Equipe = context.Equipe;

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id) {
            Equipe equipe = context.Equipe.First(x => x.IdEquipe == id);

            context.Equipe.Remove(equipe);

            context.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("/Editar/{id}")]
        public IActionResult Editar(int id) {
            Equipe equipe = context.Equipe.First(x => x.IdEquipe == id);
            ViewBag.Equipe = equipe;
            return View("Edit");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form, Equipe e) {
            Equipe novaEquipe = new Equipe();
            novaEquipe.Nome = e.Nome;

            if (form.Files.Any()) {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipe");

                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create)) {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            } else {
                novaEquipe.Imagem = "padrão.jpg";
            }

            Equipe equipe = context.Equipe.First(x => x.IdEquipe == e.IdEquipe);

            equipe.Nome = novaEquipe.Nome;
            equipe.Imagem = novaEquipe.Imagem;

            context.Equipe.Update(equipe);
            context.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}