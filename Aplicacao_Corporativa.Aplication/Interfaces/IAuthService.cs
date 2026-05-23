using Aplicacao_Corporativa.Domain.DTO;
using Aplicacao_Corporativa.Domain.Entities;

namespace Aplicacao_Corporativa.Aplication.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario?> ValidarLogin(LoginRequestDTO request);

        Task<string> CadastrarUsuario(LoginRequestDTO request);
    }
}
