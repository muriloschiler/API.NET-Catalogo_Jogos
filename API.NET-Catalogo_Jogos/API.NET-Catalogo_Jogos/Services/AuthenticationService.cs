using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Exceptions;
using API.NET_Catalogo_Jogos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthenticationService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task LoginUsuario(LoginUsuarioInputModel loginUsuario)
        {
            loginUsuario.senha = EncodePasswordToBase64(loginUsuario.senha);
            if (! await _usuarioRepository.BuscarUsuario(loginUsuario))
            {
                throw new UsuarioNotFound();
            }
        
        }

        public async Task RegistrarUsuario(RegistrarUsuarioInputModel registrarUsuarioInputModel)
        {
            if (await _usuarioRepository.BuscarUsuario(registrarUsuarioInputModel))
            {
                throw new UsuarioJaCadastrado();
            }

            Usuario novoUsuario = new Usuario
            {
                id = new Guid(),
                nome = registrarUsuarioInputModel.nome,
                email = registrarUsuarioInputModel.email,
                senha = EncodePasswordToBase64(registrarUsuarioInputModel.senha),
                dataNasc = registrarUsuarioInputModel.dataNasc,
                sexo = registrarUsuarioInputModel.sexo

            };

            await _usuarioRepository.RegistrarUsuario(novoUsuario);
        }
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}
