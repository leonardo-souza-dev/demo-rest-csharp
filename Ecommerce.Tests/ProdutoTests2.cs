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
    public class ProdutoTests2
    {
        /// eu espero conseguir gravar um produto no ProdutoRepositoryImpl
        [Test]
        public void Foo1() 
        {
            // arrange
            var nome = "TV";
            var preco = 5000;

            var sut = new ProdutoRepository();

            // act
            Produto produto = sut.Inserir(nome, preco);

            // assert
            Assert.NotNull(produto);
            Assert.AreEqual(nome, produto.Nome);
            Assert.AreEqual(preco, produto.Preco);
        }

        /// eu não devo conseguir inserir um produto quando o preço for maior que 10000
        [Test]
        public void Foo2() 
        {
            // arrange
            var nome = "TV";
            var preco = 11000;
            
            var repositoryMock = new Mock<IProdutoRepository>();
            var loggerMock = new Mock<ILogger>();
            var sut = new ProdutoService(repositoryMock.Object, loggerMock.Object);

            // act
            Produto produto = sut.Inserir(nome, preco);

            // assert
            Assert.IsNull(produto);
        }

        /// eu preciso saber se o repositório é chamado ao salvar um produto válido no serviço
        [Test]
        public void Foo3() 
        {
            // arrange
            var nome = "TV";
            var preco = 1000;
            
            var repositoryMock = new Mock<IProdutoRepository>();
            var loggerMock = new Mock<ILogger>();
            var sut = new ProdutoService(repositoryMock.Object, loggerMock.Object);

            // act
            Produto produto = sut.Inserir(nome, preco);

            // assert
            repositoryMock.Verify(x => x.Inserir(nome, preco));        
        }

        /// preciso validar que quando inserir produto com sucesso pela controller
        /// o produto retornado não tenha os atributos alterados
        [Test]
        public void Foo4()
        {
            // arrange
            var nome = "TV";
            var preco = 4000;
            var serviceMock = new Mock<IProdutoService>();
            var produtoFake = new Produto(nome, preco);
            serviceMock.Setup(x => x.Inserir(It.IsAny<string>(), It.IsAny<decimal>())).Returns(produtoFake);
            var sut = new ProdutoController(serviceMock.Object);

            // act
            var dto = sut.InserirProduto(nome, preco);

            // assert
            Assert.NotNull(dto);
            Assert.AreEqual(dto.Produto.Nome, nome);
            Assert.AreEqual(dto.Produto.Preco, preco);
        }
    }
}