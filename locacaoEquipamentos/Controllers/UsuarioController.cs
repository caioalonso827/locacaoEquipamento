using locacaoEquipamentos.models;
using locacaoEquipamentos.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace locacaoEquipamentos.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        [HttpPost("login")]
        public Usuario login(string email, string senha)
        {
            var usuario = _usuarioService.login(email, senha);
            if (usuario == null)
            {
                throw new Exception("Credenciais inválidas");
            }
            else
            {
                return usuario;
            }
        }
    }
}
