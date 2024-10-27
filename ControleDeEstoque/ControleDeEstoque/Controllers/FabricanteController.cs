using ControleDeEstoque.Entities;
using ControleDeEstoque.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Controlador para gerenciar operações relacionadas a fabricantes.
    /// </summary>
    public class FabricanteController : Controller
    {
        private AppDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="FabricanteController"/>.
        /// </summary>
        /// <param name="context">O contexto do banco de dados <see cref="AppDbContext"/> utilizado para acessar os fabricantes.</param>
        /// <remarks>
        /// Este construtor é utilizado para injetar uma instância do contexto do banco de dados, 
        /// permitindo que o controlador execute operações de criação, leitura, atualização e exclusão (CRUD) em fabricantes.
        /// </remarks>
        public FabricanteController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cria um novo fabricante no banco de dados.
        /// </summary>
        /// <param name="fabricante">O objeto <see cref="Fabricante"/> que representa o fabricante a ser criado.</param>
        /// <remarks>
        /// Este método aceita um objeto <c>Fabricante</c> contendo os dados do novo fabricante. 
        /// Os dados serão salvos no banco de dados após a execução deste método.
        /// </remarks>
        /// <returns>
        /// O objeto <see cref="Fabricante"/> que foi criado e salvo no banco de dados.
        /// </returns>
        /// <response code="201">Fabricante criado com sucesso.</response>
        /// <response code="400">Se o fabricante fornecido for inválido.</response>
        /// <response code="500">Erro ao tentar criar o fabricante.</response>
        [HttpPost("Create")]
        public Fabricante Create(Fabricante fabricante)
        {
            _context.Add(fabricante);
            _context.SaveChanges();
            return fabricante;
        }

        /// <summary>
        /// Remove um fabricante do banco de dados pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador único do fabricante a ser removido.</param>
        /// <remarks>
        /// Este método consulta o banco de dados para localizar um fabricante pelo ID fornecido. 
        /// Se encontrado, o fabricante será removido do banco de dados.
        /// </remarks>
        /// <returns>
        /// Um objeto <see cref="ActionResult"/> indicando o resultado da operação.
        /// Retorna um status <c>200 OK</c> se a remoção for bem-sucedida.
        /// </returns>
        /// <response code="200">Fabricante removido com sucesso.</response>
        /// <response code="404">Se nenhum fabricante for encontrado com o ID fornecido.</response>
        /// <response code="500">Erro ao tentar remover o fabricante.</response>
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var fabricante = _context.Fabricantes.Where(x => x.Id == id).FirstOrDefault();

            if (fabricante == null)
            {
                return NotFound(); // Retorna 404 se o fabricante não for encontrado
            }

            _context.Fabricantes.Remove(fabricante);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Atualiza um fabricante existente no banco de dados.
        /// </summary>
        /// <param name="fabricante">O objeto <see cref="Fabricante"/> contendo os dados a serem atualizados.</param>
        /// <remarks>
        /// Este método aceita um objeto <c>Fabricante</c> que deve conter o identificador do fabricante 
        /// a ser atualizado. Os dados do fabricante serão modificados no banco de dados.
        /// </remarks>
        /// <returns>
        /// O objeto <see cref="Fabricante"/> atualizado que foi salvo no banco de dados.
        /// </returns>
        /// <response code="200">Fabricante atualizado com sucesso.</response>
        /// <response code="400">Se o fabricante fornecido for inválido.</response>
        /// <response code="404">Se o fabricante com o ID especificado não for encontrado.</response>
        /// <response code="500">Erro ao tentar atualizar o fabricante.</response>
        [HttpPut("Update")]
        public Fabricante Update(Fabricante fabricante)
        {
            _context.Update(fabricante);
            _context.SaveChanges();
            return fabricante;
        }

        /// <summary>
        /// Obtém um fabricante específico pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador único do fabricante.</param>
        /// <remarks>
        /// Este método consulta o banco de dados para retornar um único fabricante com base no ID fornecido.
        /// </remarks>
        /// <returns>
        /// Um objeto do tipo <see cref="Fabricante"/> correspondente ao ID fornecido. 
        /// Retorna <c>null</c> se nenhum fabricante for encontrado com o ID especificado.
        /// </returns>
        /// <response code="200">Retorna o fabricante encontrado com sucesso.</response>
        /// <response code="404">Se nenhum fabricante for encontrado com o ID fornecido.</response>
        /// <response code="500">Erro ao tentar recuperar o fabricante.</response>
        [HttpGet("Get/{id}")]
        public Fabricante Get(int id)
        {
            return _context.Fabricantes.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet("GetAll")]
        public List<Fabricante> GetAll()
        {
            return _context.Fabricantes.ToList();
        }
    }

}
