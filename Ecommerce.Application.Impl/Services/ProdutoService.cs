using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using Ecommerce.Application.Interfaces;

namespace Ecommerce.Application.Impl.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger _logger;

        public ProdutoService(IProdutoRepository produtoRepository, ILogger logger)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
        }

        public Produto Inserir(string nome, decimal preco)
        {
            _logger.Gravar("Serviço de produto iniciado");

            if (preco > 10000)
            {
                _logger.Gravar("Preço fora da faixa permitida");
                return null;
            }

            return _produtoRepository.Inserir(nome, preco);
        }
    }
}
