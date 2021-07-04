using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.DTO.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AuthenticationContext _AuthenticationContext;

        public UsuarioRepository(AuthenticationContext authenticationContext)
        {
            _AuthenticationContext = authenticationContext;
        }
        public bool buscarUsuario(LoginUsuarioInputModel loginUsuario)
        {
            if(_AuthenticationContext.usuarios.Any(usuario => usuario.email == loginUsuario.email)
              && _AuthenticationContext.usuarios.Any(usuario => usuario.senha == loginUsuario.senha))
            {
                return true;
            }
            return false;
        }
    }
}
