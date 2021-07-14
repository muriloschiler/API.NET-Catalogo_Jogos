using API.NET_Catalogo_Jogos.Data;
using API.NET_Catalogo_Jogos.DTO.InputModels;
using API.NET_Catalogo_Jogos.Entities;
using API.NET_Catalogo_Jogos.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.NET_Catalogo_Jogos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UsuarioRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> BuscarUsuario(LoginUsuarioInputModel loginUsuario)
        {
            try
            {
                if (_applicationDbContext.usuarios.Any(usuario => usuario.email == loginUsuario.email)
                  && _applicationDbContext.usuarios.Any(usuario => usuario.senha == loginUsuario.senha))
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }    
        }

        public async Task<bool> BuscarUsuario(RegistrarUsuarioInputModel registrarUsuario)
        {
            try
            {
                if (_applicationDbContext.usuarios.Any(usuario => usuario.email == registrarUsuario.email))
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> BuscarUsuario(Guid idUsuario)
        {
            try
            {
                Usuario buscaUsuario = _applicationDbContext.usuarios.Where(usuario => usuario.id == idUsuario).FirstOrDefault();
                return buscaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RegistrarUsuario(Usuario registrarUsuario)
        {
            try
            {
                _applicationDbContext.usuarios.Add(registrarUsuario);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose(){}

        
    }
}
