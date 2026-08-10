using locacaoEquipamentos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração dos Serviços (Dependências)
builder.Services.AddControllers();

// Configuração do Banco de Dados PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do Swagger (.NET 8)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração de CORS (libera chamadas externas/front-end)
builder.Services.AddCors(options =>
{
    options.AddPolicy("LiberarTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 2. Construção da aplicação (apenas UMA vez)
var app = builder.Build();

// 3. Pipeline da Aplicação (Middleware)

// Ativa a documentação visual do Swagger em qualquer ambiente
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Locacao Equipamentos v1");
    c.RoutePrefix = string.Empty; // Abre o Swagger na raiz do site (/)
});

app.UseCors("LiberarTudo");

app.UseAuthorization();

app.MapControllers();

app.Run();