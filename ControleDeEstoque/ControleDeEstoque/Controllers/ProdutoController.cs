using ControleDeEstoque.Entities;
using ControleDeEstoque.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Controlador para gerenciar operações relacionadas aos produtos.
    /// </summary>
    public class ProdutoController : Controller
    {
        private AppDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ProdutoController"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="AppDbContext"/> que será utilizado para acessar os produtos.</param>
        /// <remarks>
        /// Este construtor é utilizado para injetar uma instância do contexto do banco de dados, 
        /// permitindo que o controlador execute operações de criação, leitura, atualização e exclusão (CRUD) em produtos.
        /// </remarks>
        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Cria um novo produto no banco de dados.
        /// </summary>
        /// <param name="produto">O objeto <see cref="Produto"/> que representa o produto a ser criado.</param>
        /// <remarks>
        /// Este método aceita um objeto <c>Produto</c> contendo os dados do novo produto. 
        /// Os dados serão salvos no banco de dados após a execução deste método.
        /// </remarks>
        /// <returns>
        /// O objeto <see cref="Produto"/> que foi criado e salvo no banco de dados.
        /// </returns>
        /// <response code="201">Produto criado com sucesso.</response>
        /// <response code="400">Se o produto fornecido for inválido.</response>
        /// <response code="500">Erro ao tentar criar o produto.</response>
        [HttpPost("Create")]
        public Produto Create(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }


        /// <summary>
        /// Remove um produto do banco de dados pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador único do produto a ser removido.</param>
        /// <remarks>
        /// Este método consulta o banco de dados para localizar um produto pelo ID fornecido. 
        /// Se encontrado, o produto será removido do banco de dados.
        /// </remarks>
        /// <returns>
        /// Um objeto <see cref="ActionResult"/> indicando o resultado da operação.
        /// Retorna um status <c>200 OK</c> se a remoção for bem-sucedida.
        /// </returns>
        /// <response code="200">Produto removido com sucesso.</response>
        /// <response code="404">Se nenhum produto for encontrado com o ID fornecido.</response>
        /// <response code="500">Erro ao tentar remover o produto.</response>
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.Where(x => x.Id == id).FirstOrDefault();

            if (produto == null)
            {
                return NotFound(); // Retorna 404 se o produto não for encontrado
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Atualiza um produto existente no banco de dados.
        /// </summary>
        /// <param name="produto">O objeto <see cref="Produto"/> contendo os dados a serem atualizados.</param>
        /// <remarks>
        /// Este método aceita um objeto <c>Produto</c> que deve conter o identificador do produto 
        /// a ser atualizado. Os dados do produto serão modificados no banco de dados.
        /// </remarks>
        /// <returns>
        /// O objeto <see cref="Produto"/> atualizado que foi salvo no banco de dados.
        /// </returns>
        /// <response code="200">Retorna o produto atualizado com sucesso.</response>
        /// <response code="400">Se o produto fornecido for inválido.</response>
        /// <response code="404">Se o produto com o ID especificado não for encontrado.</response>
        /// <response code="500">Erro ao tentar atualizar o produto.</response>
        [HttpPut("Update")]
        public Produto Update(Produto produto)
        {
            _context.Update(produto);
            _context.SaveChanges();
            return produto;
        }


        /// <summary>
        /// Obtém um produto específico pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador único do produto.</param>
        /// <remarks>
        /// Este método consulta o banco de dados para retornar um único produto com base no ID fornecido.
        /// As informações do fabricante associado ao produto também são incluídas.
        /// </remarks>
        /// <returns>
        /// Um objeto do tipo <see cref="Produto"/> correspondente ao ID fornecido. 
        /// Retorna <c>null</c> se nenhum produto for encontrado com o ID especificado.
        /// </returns>
        /// <response code="200">Retorna o produto encontrado com sucesso.</response>
        /// <response code="404">Se nenhum produto for encontrado com o ID fornecido.</response>
        /// <response code="500">Erro ao tentar recuperar o produto.</response>
        [HttpGet("Get/{id}")]
        public Produto Get(int id)
        {
            return _context.Produtos.Include(x => x.Fabricante).Where(x => x.Id == id).FirstOrDefault();
        }


        /// <summary>
        /// Obtém uma lista de todos os produtos do banco de dados.
        /// </summary>
        /// <remarks>
        /// Este método consulta o banco de dados para retornar uma lista completa de produtos, 
        /// incluindo informações sobre os fabricantes associados a cada produto.
        /// </remarks>
        /// <returns>Uma lista de objetos do tipo <see cref="Produto"/> contendo todos os produtos disponíveis no banco de dados.</returns>
        /// <response code="200">Retorna a lista de produtos com sucesso.</response>
        /// <response code="500">Erro ao tentar recuperar os produtos.</response>
        [HttpGet("GetAll")]
        public List<Produto> GetAll()
        {
            return _context.Produtos.Include(x => x.Fabricante).ToList();
        }

    }
}
