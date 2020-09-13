using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Messages;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.Models;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("/cadastrarUsuario")]
        public UsuarioDto AdicionarProdutoAoCarrinho(string email, string senha)
        {
            Usuario usuario = _identityService.CadastrarUsuario(email, senha);

            return usuario != null ? new UsuarioDto(usuario.Email, usuario.Senha) : null;
        }
    }
}
