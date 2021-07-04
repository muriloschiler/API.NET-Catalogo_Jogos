using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _config;
        public AuthenticationController(IUsuarioRepository usuarioRepository, IConfiguration config)
        {
            _usuarioRepository = usuarioRepository;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginUsuarioInputModel loginUsuario)
        {
            if (! _usuarioRepository.buscarUsuario(loginUsuario))
            {
                return NotFound("Usuario nao encontrado");
            }

            var tokenString = GerarTokenJwt();
            return Ok(new { token = tokenString });
        }
        private string GerarTokenJwt()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
