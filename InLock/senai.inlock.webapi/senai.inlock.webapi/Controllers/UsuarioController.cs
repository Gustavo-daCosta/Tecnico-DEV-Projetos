using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webapi.Domains;
using senai.inlock.webapi.Interfaces;
using senai.inlock.webapi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController() => _usuarioRepository = new UsuarioRepository();

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                    return NotFound("Usuário não encontrado");
                if (usuarioBuscado.Email == usuario.Email && usuarioBuscado.Senha != usuario.Senha)
                    return Conflict("Senha incorreta!");

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.Titulo.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-games-key-auth-webapi-dev"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "senai.inlock.webapi",
                    audience: "senai.inlock.webapi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        [Route("ListarTodos")]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarTodos()
        {
            try
            {
                List<UsuarioDomain> listaUsuarios = _usuarioRepository.ListarTodos();

                return StatusCode(200, listaUsuarios);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
