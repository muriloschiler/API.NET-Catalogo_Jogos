using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Exceptions;
using API.NET_Catalogo_Jogos.Repository;
using API.NET_Catalogo_Jogos.Services;
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
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _config;
        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration config)
        {
            _authenticationService = authenticationService;   
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginUsuarioInputModel loginUsuario)
        {
            try
            {
                await _authenticationService.LoginUsuario(loginUsuario);
                var tokenString = GerarTokenJwt();
                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(UsuarioNotFound))
                    return NotFound(ex.Message);

                return Problem(ex.Message, null, 500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(RegistrarUsuarioInputModel registrarUsuarioInputModel)
        {
            try
            {
                await _authenticationService.RegistrarUsuario(registrarUsuarioInputModel);
                return Created(HttpContext.ToString(), "Usuario cadastrado");
            }
            catch(Exception ex)
            {
                if (ex.GetType() == typeof(UsuarioJaCadastrado))
                    return UnprocessableEntity(ex.Message);

                return Problem(ex.Message, null, 500);
            }
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
