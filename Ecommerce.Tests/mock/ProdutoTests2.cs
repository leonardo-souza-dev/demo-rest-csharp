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
        [Test]
        public void NaoDeveInserirProduto_QuandoPrecoMaiorQue10000() 
        {
            // arrange
            var nome = "TV";
            var preco = 11000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();
            var mensageria = new Mock<IMensageria>();

            var sut = new ProdutoService(repository.Object, logger.Object, mensageria.Object);
            
            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            Assert.Null(produto);
        }

        [Test]
        public void DeveLogar_QuandoPrecoMaiorQue10000() 
        {
            // arrange
            var nome = "TV";
            var preco = 11000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();
            var mensageria = new Mock<IMensageria>();

            var sut = new ProdutoService(repository.Object, logger.Object, mensageria.Object);

            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            logger.Verify(x => x.Gravar("Preço fora da faixa permitida"));
        }

        [Test]
        public void DeveInserirProduto_QuandoPrecoDentroDaFaixa() 
        {   
            // arrange
            var nome = "TV";
            var preco = 3000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();
            var mensageria = new Mock<IMensageria>();
            var produtoFake = new Produto(nome, preco);
            repository.Setup(x => x.Inserir(It.IsAny<string>(), It.IsAny<decimal>())).Returns(produtoFake);

            var sut = new ProdutoService(repository.Object, logger.Object, mensageria.Object);
            
            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            Assert.NotNull(produto);
            Assert.AreEqual(nome, produto.Nome);
            Assert.AreEqual(preco, produto.Preco);
        }
    }
}