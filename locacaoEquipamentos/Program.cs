using locacaoEquipamentos;
using locacaoEquipamentos.Services.Service; // Importante para achar as suas classes de Service
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Prevenção do erro de inotify no Linux (Render)
builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables();

// 1. Configuração dos Controllers
builder.Services.AddControllers();

// 2. Configuração do Banco de Dados PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. INJEÇÃO DE DEPENDÊNCIA DOS SEUS SERVIÇOS (Faltava registrar aqui!)
builder.Services.AddScoped<movimentacaoService>();
builder.Services.AddScoped<UsuarioService>();
// Se você tiver outros serviços (ex: EquipamentoService), adicione a linha deles aqui também:
// builder.Services.AddScoped<EquipamentoService>();

// 4. Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// 5. Configuração de CORS
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

// Pipeline da Aplicação
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Locacao Equipamentos v1");
    c.RoutePrefix = string.Empty;
});

app.UseCors("LiberarTudo");
app.UseAuthorization();
app.MapControllers();

app.Run();