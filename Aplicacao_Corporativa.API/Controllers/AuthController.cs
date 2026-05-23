using Aplicacao_Corporativa.Aplication.Interfaces;
using Aplicacao_Corporativa.Domain.DTO;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao_Corporativa.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var usuario = await _authService.ValidarLogin(request);

            if (usuario == null)
            {
                // Se o usuário ou senha estiverem errados, retorna erro 401 (Não Autorizado)
                return Unauthorized(new { mensagem = "E-mail ou senha inválidos ou não existe." });
            }

            // Se deu certo, retorna os dados do usuário para o React salvar na sessão
            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                usuarioId = usuario.UsuarioId,
                nome = usuario.Nome,
                email = usuario.Email
            });
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Register([FromBody] LoginRequestDTO request)
        {
            var resultado = await _authService.CadastrarUsuario(request);

            if (resultado == "Este e-mail já está cadastrado.")
            {
                // Retorna Erro 400 (Bad Request) informando que o usuário já existe
                return BadRequest(new { mensagem = resultado });
            }

            // Retorna Sucesso 200
            return Ok(new { mensagem = "Usuário cadastrado com sucesso!" });
        }
    }
}
