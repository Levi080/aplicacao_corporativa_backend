using Aplicacao_Corporativa.Aplication.Interfaces;
using Aplicacao_Corporativa.Domain.DTO;
using Aplicacao_Corporativa.Domain.Entities;
using Aplicacao_Corporativa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Corporativa.Aplication.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CadastrarPessoa(PessoaCadastroRequestDTO request)
        {
            // 1. Validação de Negócio: Verifica se o CPF já está cadastrado
            var cpfExiste = await _context.Pessoa
                .AnyAsync(p => p.Cpf == request.Cpf);

            if (cpfExiste)
            {
                return "Este CPF já está cadastrado.";
            }

            // 2. Mapeia o DTO para a Entidade do Banco
            var novaPessoa = new Pessoa
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Nascimento = request.Nascimento,
                Telefone = request.Telefone,
                PessoaTipoId = request.PessoaTipoId,
                AtualizadoPor = request.AtualizadoPor,
                AtualizadoEm = DateTime.UtcNow 
            };

            // 3. Salva no banco
            _context.Pessoa.Add(novaPessoa);
            await _context.SaveChangesAsync();

            return "Sucesso";
        }

        public async Task<List<PessoaResponseDTO>> ListarPessoas()
        {
            var pessoas = await _context.Pessoa
                .Include(p => p.Tipo) // Faz o "JOIN" com a tabela pessoatipo automaticamente
                .ToListAsync();

            // Mapeia a lista de Entidades do banco para a lista de DTOs que o React vai ler
            return pessoas.Select(p => new PessoaResponseDTO
            {
                PessoaId = p.PessoaId,
                Nome = p.Nome,
                Cpf = p.Cpf,
                Nascimento = p.Nascimento,
                Telefone = p.Telefone,
                PessoaTipoId = p.PessoaTipoId,
                DescricaoTipoPessoa = p.Tipo != null ? p.Tipo.Descricao : "Não Informado", // Pega o nome do tipo
                AtualizadoPor = p.AtualizadoPor,
                AtualizadoEm = p.AtualizadoEm
            }).ToList();
        }
    }
}
