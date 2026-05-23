using Aplicacao_Corporativa.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Corporativa.Aplication.Interfaces
{
    public interface IPessoaService
    {
        Task<string> CadastrarPessoa(PessoaCadastroRequestDTO request);

        Task<List<PessoaResponseDTO>> ListarPessoas();

        Task<string> AtualizarPessoa(PessoaCadastroRequestDTO request);

        Task<string> ExcluirPessoa(int id);
    }
}
