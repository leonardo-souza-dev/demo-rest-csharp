using Ecommerce.Application.Impl.Services;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Repository;
using Ecommerce.Api.Controllers;
using Moq;
using Xunit;

namespace Ecommerce.Tests
{
    public class ProdutoTests2
    {
        [Fact]
        public void NaoDeveInserirProduto_QuandoPrecoMaiorQue10000()
        {
            // arrange
            var nome = "TV";
            var preco = 11000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILoggerService>();
            var mensageria = new Mock<IMensageriaService>();

            var sut = new ProdutoService(repository.Object, logger.Object, mensageria.Object);

            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            Assert.Null(produto);
        }

        [Fact]
        public void DeveLogar_QuandoPrecoMaiorQue10000()
        {
            // arrange
            var nome = "TV";
            var preco = 11000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILoggerService>();
            var mensageria = new Mock<IMensageriaService>();

            var sut = new ProdutoService(repository.Object, logger.Object, mensageria.Object);

            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            logger.Verify(x => x.Gravar("Preço fora da faixa permitida"));
        }

        [Fact]
        public void DeveInserirProduto_QuandoPrecoDentroDaFaixa()
        {
            // arrange
            var nome = "TV";
            var preco = 3000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILoggerService>();
            var mensageria = new Mock<IMensageriaService>();
            var produtoFake = new Produto(nome, preco);
            repository.Setup(x => x.Inserir(It.IsAny<string>(), It.IsAny<decimal>())).Returns(produtoFake);

            var sut = new ProdutoService(repository.Object, logger.Object, mensageria.Object);

            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            Assert.NotNull(produto);
            Assert.Equal(nome, produto.Nome);
            Assert.Equal(preco, produto.Preco);
        }
    }
}