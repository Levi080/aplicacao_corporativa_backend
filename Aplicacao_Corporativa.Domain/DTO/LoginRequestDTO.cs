
namespace Aplicacao_Corporativa.Domain.DTO
{
    public class LoginRequestDTO
    {
        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public string? Nome { get; set; } = null!;
    }
}
