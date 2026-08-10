using locacaoEquipamentos.models;
using Microsoft.EntityFrameworkCore;

namespace locacaoEquipamentos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Movimentacao> Movimentacaos { get; set; }

    }
}
