using Ecommerce.Application.Messages;
using Ecommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("inserirProduto")]
        public ProdutoDto InserirProduto(string nome, decimal preco)
        {
            var produto = _produtoService.Inserir(nome, preco);

            if (produto != null)
            {
                return new ProdutoDto(produto, true, "Produto inserido com sucesso");
            }
            else
            {
                return new ProdutoDto(produto, false, "Ocorreu um erro ao inserir o produto");
            }
        }
    }
}
