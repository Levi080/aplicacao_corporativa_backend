using Aplicacao_Corporativa.Aplication.Interfaces;
using Aplicacao_Corporativa.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao_Corporativa.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] PessoaCadastroRequestDTO request)
        {
            var resultado = await _pessoaService.CadastrarPessoa(request);

            if (resultado == "Este CPF já está cadastrado." || resultado == "O Tipo de Pessoa informado é inválido.")
            {
                return BadRequest(new { mensagem = resultado });
            }

            return Ok(new { mensagem = "Pessoa cadastrada com sucesso!" });
        }


        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var pessoas = await _pessoaService.ListarPessoas();

            // Retorna a lista (mesmo se estiver vazia []) com status 200 OK
            return Ok(pessoas);
        }


        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] PessoaCadastroRequestDTO request)
        {
            var resultado = await _pessoaService.AtualizarPessoa(request);

            if (resultado == "Pessoa não encontrada.")
            {
                return NotFound(new { mensagem = resultado });
            }

            if (resultado == "Este CPF já está sendo usado por outra pessoa." || resultado == "O Tipo de Pessoa informado é inválido.")
            {
                return BadRequest(new { mensagem = resultado });
            }

            return Ok(new { mensagem = "Pessoa atualizada com sucesso!" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var resultado = await _pessoaService.ExcluirPessoa(id);

            if (resultado == "Pessoa não encontrada.")
            {
                return NotFound(new { mensagem = resultado });
            }

            if (resultado == "Não é possível excluir esta pessoa pois ela possui exames vinculados.")
            {
                return BadRequest(new { mensagem = resultado });
            }

            return Ok(new { mensagem = "Pessoa excluída com sucesso!" });
        }
    }
}
