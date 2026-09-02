using locacaoEquipamentos.models;
using locacaoEquipamentos.models.Dto;

namespace locacaoEquipamentos.Services.Service
{
    public class UsuarioService
    {

        private readonly AppDbContext _appDbContext;

        public UsuarioService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Usuario login (Login login)
        {
            var usuario = _appDbContext.Usuarios.FirstOrDefault(u => u.email == login.email && u.senha == login.senha);
            return usuario;
        }
    }
}
