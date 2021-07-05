using API.NET_Catalogo_Jogos.DTO.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Services
{
    public interface IAuthenticationService
    {
        public Task LoginUsuario(LoginUsuarioInputModel loginUsuarioInputModel);


        public Task RegistrarUsuario(RegistrarUsuarioInputModel registrarUsuarioInputModel);
    }
}
