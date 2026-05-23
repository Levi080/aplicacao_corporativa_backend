using Aplicacao_Corporativa.Aplication.Interfaces;
using Aplicacao_Corporativa.Domain.DTO;
using Aplicacao_Corporativa.Domain.Entities;
using Aplicacao_Corporativa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace Aplicacao_Corporativa.Aplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ValidarLogin(LoginRequestDTO request)
        {
            // 1. Converte a senha que veio do React em Bytes (para bater com o tipo BYTEA do banco)
            byte[] senhaEmBytes = Encoding.UTF8.GetBytes(request.Senha);

            // 2. Busca no banco um usuário com o mesmo e-mail e mesma senha
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email == request.Email && u.Senha_Hash == senhaEmBytes);

            return usuario; // Se não achar, retorna null. Se achar, retorna o usuário.
        }

        public async Task<string> CadastrarUsuario(LoginRequestDTO request)
        {
            // 1. Verifica se já existe algum usuário com o e-mail informado
            var usuarioExiste = await _context.Usuario
                .AnyAsync(u => u.Email.ToLower() == request.Email.ToLower());

            if (usuarioExiste)
                return "Este e-mail já está cadastrado.";        

            // 2. Transforma a string da senha em bytes para salvar no banco (BYTEA)
            byte[] senhaEmBytes = Encoding.UTF8.GetBytes(request.Senha);
            byte[] saltFicticio = Encoding.UTF8.GetBytes("salt_faculdade"); // Apenas para preencher o campo do banco

            // 3. Cria o objeto da entidade
            var novoUsuario = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha_Hash = senhaEmBytes,
                Senha_Salt = saltFicticio,
                Ativo = true,
                DataCriacao = DateTime.UtcNow
            };

            // 4. Salva no banco de dados hospedado
            _context.Usuario.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return "Sucesso";
        }
    }
}
