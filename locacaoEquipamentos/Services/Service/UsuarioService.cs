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

        public usuario login (Login login)
        {
            var usuario = _appDbContext.usuario.FirstOrDefault(u => u.email == login.email && u.senha == login.senha);
            return usuario;
        }
    }
}
