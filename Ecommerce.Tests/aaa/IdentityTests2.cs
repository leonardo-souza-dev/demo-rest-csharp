using Ecommerce.Domain.Models;
using Ecommerce.Application.Impl.Services;
using Xunit;

namespace Ecommerce.Tests
{
    public class IdentityTests2
    {
        [Fact]
        public void NaoDeveCadastrarUsuarioComSenhaCurta()
        {
            // arrange
            string email = "testes@testes.com";
            string senha = "1";

            IdentityService sut = new IdentityService();

            // act
            Usuario usuario = sut.CadastrarUsuario(email, senha);

            // assert
            Assert.Null(usuario);
        }
    }
}