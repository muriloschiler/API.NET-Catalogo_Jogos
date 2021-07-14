using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        public Task<bool> BuscarUsuario(LoginUsuarioInputModel loginUsuario);
        public Task<bool> BuscarUsuario(RegistrarUsuarioInputModel registrarUsuario);
        public Task<Usuario> BuscarUsuario(Guid idUsuario);
        public Task RegistrarUsuario(Usuario registrarUsuario);
        

    }
}
