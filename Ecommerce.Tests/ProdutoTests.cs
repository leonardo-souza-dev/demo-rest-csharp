using Ecommerce.Application.Impl.Services;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Repository;
using Ecommerce.Api.Controllers;
using Moq;
using NUnit.Framework;
  
namespace Ecommerce.Tests
{
    public class ProdutoTests
    {
        /// eu espero conseguir gravar um produto no ProdutoRepositoryImpl
        [Test]
        public void Foo1() 
        {
        }

        /// eu não devo conseguir inserir um produto quando o preço for maior que 10000
        [Test]
        public void Foo2() 
        {
        }

        /// eu preciso saber se o repositório é chamado ao salvar um produto válido no serviço
        [Test]
        public void Foo3() 
        {       
        }

        /// preciso validar que quando inserir produto com sucesso pela controller
        /// o produto retornado não tenha os atributos alterados
        [Test]
        public void Foo4()
        {
        }
    }
}