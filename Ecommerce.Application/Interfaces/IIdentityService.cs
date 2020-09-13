using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces
{
    public interface IIdentityService
    {
        Usuario CadastrarUsuario(string email, string senha);
    }
}
