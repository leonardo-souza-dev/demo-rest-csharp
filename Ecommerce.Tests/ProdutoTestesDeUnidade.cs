using Ecommerce.Domain.Models;
using Ecommerce.Application.Impl.Services;
using NUnit.Framework;
  
namespace Ecommerce.Tests
{
    public class ProdutoTestesDeUnidade
    {        
        [Test]
        public void NaoDeveCadastrarUsuarioComSenhaCurta()
        {
            string email = "testes@testes.com";
            string senha = "1";

            IdentityService sut = new IdentityService();

            Usuario usuario = sut.CadastrarUsuario(email, senha);

            Assert.IsNull(usuario);
        }
    }
}