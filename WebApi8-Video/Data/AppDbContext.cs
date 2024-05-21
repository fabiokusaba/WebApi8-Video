using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Models;

namespace WebApi8_Video.Data
{
    //Conexão ao banco de dados
    public class AppDbContext : DbContext
    {
        //Passando ao construtor do nosso context que ele precisa receber algumas opções e informações de conexão para que
        //ele consiga fazer o serviço de meio de campo
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Especificando as tabelas que quero criar com seus respectivos modelos
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
