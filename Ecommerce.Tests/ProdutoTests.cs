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
        public void ConsigoInserirProdutoNoRepositorio() 
        {
            // arrange
                var logger = new Mock<ILogger>();
                var repository = new Mock<IProdutoRepository>();
                var preco = 9000;
                var nome = "TV";

                repository
                    .Setup(x => x.Inserir(It.IsAny<string>(), It.IsAny<decimal>()))
                    .Returns(new Produto(nome, preco));

                var sut = new ProdutoService(repository.Object, logger.Object);
            // act
                var result = sut.Inserir(nome, preco);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Nome, nome);
            Assert.AreEqual(result.Preco, preco);
            repository.Verify(x => x.Inserir(nome, preco));
        }

        /// eu não devo conseguir inserir um produto quando o preço for maior que 10000
        [Test]
        public void NaoInserirProdutoNoRepositorioQuandoPrecoMaior10000() 
        {

            // arrange
            var logger = new Mock<ILogger>();
            var repository = new Mock<IProdutoRepository>();
            var preco = 25000;
            var nome = "TV Plansta 64";

            var sut = new ProdutoService(repository.Object, logger.Object);

            // act
            var result = sut.Inserir(nome, preco);

            // assert
            Assert.IsNull(result);
        }

        /// eu preciso saber se o repositório é chamado ao salvar um produto válido no serviço
        [Test]
        public void RepositorioChamadoAoSalvarProduto() 
        {       
            // arrange
            var logger = new Mock<ILogger>();
            var repository = new Mock<IProdutoRepository>();
            var preco = 9000;
            var nome = "TV";

            var sut = new ProdutoService(repository.Object, logger.Object);
            
            // act
            sut.Inserir(nome, preco);

            // assert
            repository.Verify(x => x.Inserir(nome, preco));
        }

        /// preciso validar que quando inserir produto com sucesso pela controller
        /// o produto retornado não tenha os atributos alterados
        [Test]
        public void DevoInserirProdutoComSucesso()
        {
            // arrange
            var logger = new Mock<ILogger>();
            var repository = new Mock<IProdutoRepository>();
            var service = new Mock<IProdutoService>();
            var preco = 9000;
            var nome = "TV";

            service
                .Setup(x => x.Inserir(It.IsAny<string>(), It.IsAny<decimal>()))
                .Returns(new Produto(nome, preco));

            var sut = new ProdutoController(service.Object);

            // act
            var result = sut.InserirProduto(nome, preco);

            // assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Produto);
            Assert.AreEqual(result.Produto.Nome, nome);
            Assert.AreEqual(result.Produto.Preco, preco);
            Assert.AreEqual("Produto inserido com sucesso", result.Mensagem);
        }
    }
}