using Ecommerce.Application.Impl.Services;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Repository;
using Ecommerce.Api.Controllers;
using Moq;
using NUnit.Framework;
using Ecommerce.Application.Messages;
  
namespace Ecommerce.Tests
{
    public class ProdutoTests
    {
        
        // K.I.S.S
        // Y.A.G.N.I

        
        /// eu espero conseguir gravar um produto no ProdutoRepository
        [Test]
        public void Foo1() 
        {
            //Arrange
            var produtoExcepted = new Produto("Teclado", 121);
            var repository = new ProdutoRepository();
            var nome = "Teclado";
            decimal preco = 121;
            
            //ACT
            var actual = repository.Inserir(nome, preco);
            
            //Assert
            Assert.IsAssignableFrom<Produto>(actual);
            Assert.AreEqual(produtoExcepted.Nome, actual.Nome);
            Assert.AreEqual(produtoExcepted.Preco, actual.Preco);
        }
        

        /// eu não devo conseguir inserir um produto quando o preço for maior que 10000
        [Test]
        public void Foo2() 
        {
            //Arrange
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();
            var s = new ProdutoService(repository.Object, logger.Object);
            var nome = "iphone 12";
            decimal preco = 10001;

            //ACT
            var actual = s.Inserir(nome, preco);

            //Assert
            Assert.IsNull(actual);
            logger.Verify(x=> x.Gravar("Preço fora da faixa permitida"), Times.Exactly(1));
        }

        /// eu preciso saber se o repositório é chamado ao salvar um produto válido no serviço
        [Test]
        public void Foo3() 
        {
            //Arrange
            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();
            var nome = "iphone 12";
            decimal preco = 10;
            repository.Setup(x=> x.Inserir(nome, preco)).Returns(new Produto(nome, preco));
            var s = new ProdutoService(repository.Object, logger.Object);
            
            //ACT
            var actual = s.Inserir(nome, preco);

            //Assert
            repository.Verify(x=> x.Inserir(nome, preco), Times.Exactly(1));
        }

        /// preciso validar que quando inserir produto com sucesso pela controller
        /// o produto retornado não tenha os atributos alterados
        [Test]
        public void Foo4()
        {
            //Arrange
            var serviceMock = new Mock<IProdutoService>();
            var controller =  new ProdutoController(serviceMock.Object);
            var nome = "Iphone";
            var preco = 2000;
            serviceMock.Setup(x=> x.Inserir(nome, preco)).Returns(new Produto(nome, preco));

            //Act
            var actual = controller.InserirProduto(nome, preco);

            //Assert
            Assert.IsAssignableFrom<ProdutoDto>(actual);
            Assert.IsAssignableFrom<Produto>(actual.Produto);
            Assert.NotNull(actual.Produto);
            Assert.AreEqual(nome, actual.Produto.Nome);
            Assert.AreEqual(preco, actual.Produto.Preco);
        }
    }
}