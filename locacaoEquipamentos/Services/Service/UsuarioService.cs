using locacaoEquipamentos.models;

namespace locacaoEquipamentos.Services.Service
{
    public class UsuarioService
    {

        private readonly AppDbContext _appDbContext;

        public UsuarioService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Usuario login (string email, string senha)
        {
            var usuario = _appDbContext.Usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);
            return usuario;
        }
    }
}
