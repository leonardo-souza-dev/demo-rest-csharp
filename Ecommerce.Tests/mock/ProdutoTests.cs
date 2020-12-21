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
        [Test]
        public void naoDeveInserirProdutoNaBaseSePrecoMaiorQue10000() 
        {
        }

        [Test]
        public void deveLogarQuandoPrecoForaDaFaixa() 
        {
        }

        [Test]
        public void deveRetornarMensagemCorretaAoInserirProdutoNaController() 
        {  
        }
    }
}