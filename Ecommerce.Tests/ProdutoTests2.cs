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
        public void naoDeveInserirProdutoNaBaseSePrecoMaiorQue10000() 
        {
            // arrange
            var nome = "TV";
            var preco = 11000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();

            var sut = new ProdutoService(repository.Object, logger.Object);
            
            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            Assert.Null(produto);
        }

        [Test]
        public void deveLogarQuandoPrecoForaDaFaixa() 
        {
            // arrange
            var nome = "TV";
            var preco = 11000;
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();

            var sut = new ProdutoService(repository.Object, logger.Object);
            
            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            logger.Verify(x => x.Gravar("Preço fora da faixa permitida"));
        }

        [Test]
        public void deveRetornarMensagemCorretaAoInserirProdutoNaController() 
        {   
            // arrange
            var nome = "TV";
            var preco = 11000;
            var service = new Mock<IProdutoService>();
            var produtoFake = new Produto(nome, preco);
            service.Setup(x => x.Inserir(It.IsAny<string>(), It.IsAny<decimal>())).Returns(produtoFake);

            var sut = new ProdutoController(service.Object);
            
            // act
            var produto = sut.InserirProduto(nome, preco);

            // assert
            Assert.NotNull(produto);
            Assert.AreEqual("Produto inserido com sucesso", produto.Mensagem);
        }
    }
}