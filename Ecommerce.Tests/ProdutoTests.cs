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

        // K.I.S.S.
        // keep it stupid simple

        // Y.A.G.N.I
        // you aint gonna need it


        /// eu espero conseguir gravar um produto no ProdutoRepository
        [Test]
        public void Dado_que_eu_esteja_no_repo_entao_eu_consigo_gravar_um_produto() 
        {
            // arrange
            var nome = "PS5";
            var preco = 5000;

            var sut = new ProdutoRepository();

            // act
            var produto = sut.Inserir(nome, preco);

            // assert
            Assert.NotNull(produto);
            Assert.AreEqual(nome, produto.Nome);
            Assert.AreEqual(preco, produto.Preco);
        }

        /// eu não devo conseguir inserir um produto quando o preço for maior que 10000
        [Test]
        public void Dado_que_eu_esteja_no_servico_Quando_gravar_um_produto_com_preco_grande_Entao_nao_devo_conseguir() 
        {
            // arrange
            var nome = "TV";
            var preco = 10001;

            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();
            var sut = new ProdutoService(repository.Object, logger.Object);

            // act
            Produto produto = sut.Inserir(nome, preco);

            // assert
            Assert.IsNull(produto);
        }

        /// eu preciso saber se o repositório é chamado ao salvar um produto válido no serviço
        [Test]
        public void Dado_que_eu_esteja_no_servico_Quando_passo_um_produto_valido_Entao_o_repo_eh_chamado() 
        {
            // arrange
            var nome = "TV";
            var preco = 5000;

            var repository = new Mock<IProdutoRepository>();
            var logger = new Mock<ILogger>();

            var sut = new ProdutoService(repository.Object, logger.Object);

            // act
            sut.Inserir(nome, preco);

            // assert
            repository.Verify(x => x.Inserir(nome, preco));
        }

        /// preciso validar que quando inserir produto com sucesso pela controller
        /// o produto retornado não tenha os atributos alterados
        [Test]
        public void Preciso_validar_o_produto_quando_inserir_corretament_via_controller()
        {
            // arrange
            var nome = "PC GAMER";
            var preco = 4000;

            var fake = new Produto(nome, preco);
            var produtoService = new Mock<IProdutoService>();
            produtoService.Setup(x => x.Inserir(It.IsAny<string>(), It.IsAny<decimal>())).Returns(fake);
            var sut = new ProdutoController(produtoService.Object);

            // act
            var dto = sut.InserirProduto(nome, preco);

            // assert
            Assert.NotNull(dto);
            Assert.AreEqual(dto.Produto.Nome, nome);
            Assert.AreEqual(dto.Produto.Preco, preco);
        }
    }
}