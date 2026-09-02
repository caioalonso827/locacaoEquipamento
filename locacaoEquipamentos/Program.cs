using locacaoEquipamentos;
using locacaoEquipamentos.Services.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração de escuta no IP 0.0.0.0 na porta dinâmica do Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Configuração de arquivos sem reload automático para otimizar uso de memória
builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables();

// Controllers e Banco de Dados
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de Dependências
builder.Services.AddScoped<movimentacaoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<equipamentoService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("LiberarTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Middlewares
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Locacao Equipamentos v1");
    c.RoutePrefix = string.Empty; // Swagger como página inicial
});

app.UseCors("LiberarTudo");
app.UseAuthorization();
app.MapControllers();

app.Run();