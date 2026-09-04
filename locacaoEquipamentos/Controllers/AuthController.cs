using locacaoEquipamentos.models;
using locacaoEquipamentos.models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace locacaoEquipamentos.Controllers
{
    [ApiController]
    [Route("AuthController")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext appDbContext)
        {
            appDbContext = _context;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            usuario usuario = _context.usuario.FirstOrDefault(c=> c.email == login.email && c.senha == login.senha);

            if (usuario == null)
            {
                return Unauthorized("Credenciais Inválidas");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("5e61d90f9fec0b9616506f863be40a770c540fcace655f6e3330e897487f632b");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, login.email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
