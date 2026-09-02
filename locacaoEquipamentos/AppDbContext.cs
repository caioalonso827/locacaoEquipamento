using locacaoEquipamentos.models;
using Microsoft.EntityFrameworkCore;

namespace locacaoEquipamentos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<usuario> usuario { get; set; }
        public DbSet<equipamentos> equipamentos { get; set; }
        public DbSet<movimentacao> movimentacao { get; set; }

    }
}
