using Ecommerce.Domain.Models;
using Ecommerce.Application.Impl.Services;
using NUnit.Framework;
  
namespace Ecommerce.Tests
{
    public class IdentityTests2
    {        
        [Test]
        public void NaoDeveCadastrarUsuarioComSenhaCurta()
        {
            // arrange
            string email = "testes@testes.com";
            string senha = "1";

            IdentityService sut = new IdentityService();

            // act
            Usuario usuario = sut.CadastrarUsuario(email, senha);

            // assert
            Assert.IsNull(usuario);
        }
    }
}