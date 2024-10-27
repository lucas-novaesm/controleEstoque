using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.Entities
{
    // Representa um fabricante no sistema de controle de estoque.
    public class Fabricante
    {
        // Identificador único do fabricante. Este campo é a chave primária da tabela no banco de dados.
        [Key]
        public int Id { get; set; }
        // Nome do fabricante.
        public string Nome { get; set; }
    }

}
