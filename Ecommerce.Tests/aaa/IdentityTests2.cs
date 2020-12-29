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
            var email = "testes@testes.com";
            var senha = "1";

            var sut = new IdentityService();

            // act
            var usuario = sut.CadastrarUsuario(email, senha);

            // assert
            Assert.Null(usuario);
        }
    }
}