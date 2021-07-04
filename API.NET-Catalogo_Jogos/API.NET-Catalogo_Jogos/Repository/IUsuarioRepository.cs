using API.NET_Catalogo_Jogos.DTO.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public interface IUsuarioRepository
    {
        public bool buscarUsuario(LoginUsuarioInputModel loginUsuario);

    }
}
