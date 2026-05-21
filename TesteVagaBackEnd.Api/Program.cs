using Services;

// Cria o construtor da aplicação
var builder = WebApplication.CreateBuilder(args);

// Permite que a aplicação use Controllers para receber e responder requisições HTTP
builder.Services.AddControllers();

// Configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProdutoRepository>();
// Usa Scope porque representa uma execução de uma requisição
builder.Services.AddScoped<ProdutoService>(); 

// Antes do build, registra dependencias
var app  = builder.Build();
// Depois do build, configura como a aplicação vai responder à requisições

// Ativa o swagger
app.UseSwagger();
app.UseSwaggerUI();

// Usar as rotas que estão nos controllers
app.MapControllers();

app.Run();

