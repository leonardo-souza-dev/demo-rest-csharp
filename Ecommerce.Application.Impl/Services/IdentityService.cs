using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Impl.Services
{
    public class IdentityService : IIdentityService
    {
        public Usuario CadastrarUsuario(string email, string senha) =>
            senha.Length > 8 ? new Usuario(email, senha) : null;
    }
}
