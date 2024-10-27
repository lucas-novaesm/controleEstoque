using ControleDeEstoque.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Infra
{
    // Representa o contexto do banco de dados para a aplicação.
    // Herda de DbContext, que fornece a funcionalidade para interagir com o banco de dados.
    public class AppDbContext : DbContext
    {
        // Construtor que aceita opções de configuração para o contexto.
        // Utiliza a classe base DbContext para aplicar as opções fornecidas.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Conjunto de entidades do tipo Fabricante que será mapeado para a tabela "Fabricantes" no banco de dados.
        public DbSet<Fabricante> Fabricantes { get; set; }

        // Conjunto de entidades do tipo Produto que será mapeado para a tabela "Produtos" no banco de dados.
        public DbSet<Produto> Produtos { get; set; }
    }

}
