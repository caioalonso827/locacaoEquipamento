using locacaoEquipamentos.models;
using locacaoEquipamentos.models.Dto;
using locacaoEquipamentos.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics;

namespace locacaoEquipamentos.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public Usuario login([FromBody] Login login)
        {
            var usuario = _usuarioService.login(login);
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
