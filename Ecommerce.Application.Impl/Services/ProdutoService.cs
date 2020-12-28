using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Impl.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILoggerService _loggerService;
        private readonly IMensageriaService _mensageriaService;

        public ProdutoService(IProdutoRepository produtoRepository, ILoggerService loggerService, IMensageriaService mensageriaService)
        {
            _produtoRepository = produtoRepository;
            _loggerService = loggerService;
            _mensageriaService = mensageriaService;
        }

        public Produto Inserir(string nome, decimal preco)
        {
            _loggerService.Gravar("Serviço de produto iniciado");

            if (preco > 10000)
            {
                _loggerService.Gravar("Preço fora da faixa permitida");
                return null;
            }

            var produto = _produtoRepository.Inserir(nome, preco);

            if (produto != null)
            {
                _mensageriaService.Enviar(produto);

                return produto;
            }

            return null;
        }
    }
}
