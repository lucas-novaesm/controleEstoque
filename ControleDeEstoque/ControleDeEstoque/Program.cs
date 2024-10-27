using ControleDeEstoque.Controllers;
using ControleDeEstoque.Infra;
using Microsoft.EntityFrameworkCore;

// Cria um novo construtor de aplicativo web utilizando os argumentos fornecidos.
var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner de injeção de dependência do aplicativo.

// Adiciona suporte para controladores no aplicativo.
// A opção SuppressImplicitRequiredAttributeForNonNullableReferenceTypes é configurada 
// para evitar que propriedades de referência não anuláveis sejam tratadas como obrigatórias automaticamente.
builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Aprende mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
// Adiciona suporte para a exploração de endpoints da API.
builder.Services.AddEndpointsApiExplorer();

// Adiciona geração de documentação Swagger para a API, facilitando a visualização e teste da API.
builder.Services.AddSwaggerGen();

// Configura o contexto do banco de dados, utilizando SQL Server.
builder.Services.AddDbContext<AppDbContext>(cfg =>
{
    // Obtém a string de conexão do banco de dados a partir da configuração do aplicativo.
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"));
});


// Registra o FabricanteController como um serviço escopado.
// Um novo FabricanteController será criado para cada solicitação HTTP,
// garantindo que cada instância tenha seu próprio estado e dependências.
builder.Services.AddScoped<FabricanteController>();

// Registra o ProdutoController como um serviço escopado.
// Um novo ProdutoController será criado para cada solicitação HTTP,
// garantindo que cada instância tenha seu próprio estado e dependências.
builder.Services.AddScoped<ProdutoController>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
