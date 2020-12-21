using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Impl.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ILogger _logger;
        private readonly IMensageria _mensageria;

        public ProdutoService(IProdutoRepository produtoRepository, ILogger logger, IMensageria mensageria)
        {
            _produtoRepository = produtoRepository;
            _logger = logger;
            _mensageria = mensageria;
        }

        public Produto Inserir(string nome, decimal preco)
        {
            _logger.Gravar("Serviço de produto iniciado");

            if (preco > 10000)
            {
                _logger.Gravar("Preço fora da faixa permitida");
                return null;
            }

            var produto = _produtoRepository.Inserir(nome, preco);

            if (produto != null)
            {
                _mensageria.Enviar(produto);

                return produto;
            }

            return null;
        }
    }
}
