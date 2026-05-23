using Aplicacao_Corporativa.Aplication.Interfaces;
using Aplicacao_Corporativa.Aplication.Services;
using Aplicacao_Corporativa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao_Corporativa.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactAppPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:5173", "https://aplicacao-corporativa-front.onrender.com") // A URL do seu Vite/React
                          .AllowAnyHeader()                     // Permite qualquer cabeçalho (Content-Type, etc)
                          .AllowAnyMethod();                    // Permite GET, POST, PUT, DELETE
                });
            });
            #endregion

            #region CONFIGURAÇÕES BANCO DE DADOS

            // Registrar o DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region ADIÇÃO DOS SERVIÇOS 
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPessoaService, PessoaService>();
            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("ReactAppPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
