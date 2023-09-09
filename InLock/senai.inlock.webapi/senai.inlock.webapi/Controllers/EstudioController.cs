using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webapi.Domains;
using senai.inlock.webapi.Interfaces;
using senai.inlock.webapi.Repositories;

namespace senai.inlock.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController() => _estudioRepository = new EstudioRepository();

        [HttpGet]
        [Route("ListarTodos")]
        [Authorize]
        public IActionResult ListarTodos()
        {
            try
            {
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                return StatusCode(200, listaEstudios);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(EstudioDomain estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return Created("Objeto criado", estudio);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204, id);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
