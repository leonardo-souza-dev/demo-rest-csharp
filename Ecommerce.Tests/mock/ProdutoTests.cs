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
    public class ProdutoTests
    {
        [Fact]
        public void naoDeveInserirProdutoNaBaseSePrecoMaiorQue10000()
        {
        }

        [Fact]
        public void deveLogarQuandoPrecoForaDaFaixa()
        {
        }

        [Fact]
        public void deveRetornarMensagemCorretaAoInserirProdutoNaController()
        {
        }
    }
}