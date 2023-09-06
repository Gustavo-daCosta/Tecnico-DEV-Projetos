using Microsoft.AspNetCore.Mvc;
using senai.inlock.webapi.Domains;
using senai.inlock.webapi.Interfaces;
using senai.inlock.webapi.Repositories;

namespace senai.inlock.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : Controller
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController() => _jogoRepository = new JogoRepository();

        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            try
            {
                List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

                return StatusCode(200, listaJogos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(JogoDomain jogo)
        {
            try
            {
                _jogoRepository.Cadastrar(jogo);

                return Created("Objeto criado", jogo);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return StatusCode(204, id);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
