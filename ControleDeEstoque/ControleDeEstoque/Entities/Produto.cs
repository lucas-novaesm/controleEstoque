using System.ComponentModel.DataAnnotations;
using ControleDeEstoque.Entities.Enums;

namespace ControleDeEstoque.Entities
{
    // Representa um produto no sistema de controle de estoque.
    public class Produto
    {
        // Identificador único do produto. Este campo é a chave primária da tabela no banco de dados.
        [Key]
        public int Id { get; set; }
        // Nome do produto.
        public string Nome { get; set; }
        // Peso do produto em unidades adequadas (ex: kg, g).
        public double Peso { get; set; }
        // Quantidade disponível do produto em estoque.
        public int QuantidadeEmEstoque { get; set; }
        // Identificador do fabricante associado a este produto.
        public int FabricanteId { get; set; }
        // Navegação para o objeto Fabricante, permitindo acessar informações do fabricante do produto.
        public Fabricante Fabricante { get; set; }
        // Categoria do produto, representada por um enum.
        public CategoriaEnum Categoria { get; set; }
    }

}
