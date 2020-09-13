using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Impl.Services
{
    public class IdentityService : IIdentityService
    {
        public Usuario CadastrarUsuario(string email, string senha)
        {
            if (!validarDados(senha)) {
                return null;
            }

            //implementação de persistência aqui
        
            return new Usuario(email, senha);
        }

    private bool validarDados(string senha) {        
        return senha.Length > 8;
    }
    }
}
