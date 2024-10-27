using ControleDeEstoque.Controllers;
using ControleDeEstoque.Infra;
using Microsoft.EntityFrameworkCore;

// Cria um novo construtor de aplicativo web utilizando os argumentos fornecidos.
var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner de inje��o de depend�ncia do aplicativo.

// Adiciona suporte para controladores no aplicativo.
// A op��o SuppressImplicitRequiredAttributeForNonNullableReferenceTypes � configurada 
// para evitar que propriedades de refer�ncia n�o anul�veis sejam tratadas como obrigat�rias automaticamente.
builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Aprende mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
// Adiciona suporte para a explora��o de endpoints da API.
builder.Services.AddEndpointsApiExplorer();

// Adiciona gera��o de documenta��o Swagger para a API, facilitando a visualiza��o e teste da API.
builder.Services.AddSwaggerGen();

// Configura o contexto do banco de dados, utilizando SQL Server.
builder.Services.AddDbContext<AppDbContext>(cfg =>
{
    // Obt�m a string de conex�o do banco de dados a partir da configura��o do aplicativo.
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver"));
});


// Registra o FabricanteController como um servi�o escopado.
// Um novo FabricanteController ser� criado para cada solicita��o HTTP,
// garantindo que cada inst�ncia tenha seu pr�prio estado e depend�ncias.
builder.Services.AddScoped<FabricanteController>();

// Registra o ProdutoController como um servi�o escopado.
// Um novo ProdutoController ser� criado para cada solicita��o HTTP,
// garantindo que cada inst�ncia tenha seu pr�prio estado e depend�ncias.
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
