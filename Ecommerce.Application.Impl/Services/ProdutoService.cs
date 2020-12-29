using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Impl.Services
{
    public record ProdutoService(IProdutoRepository ProdutoRepository,
                                 ILoggerService LoggerService,
                                 IMensageriaService MensageriaService) : IProdutoService
    {
        public Produto Inserir(string nome, decimal preco)
        {
            LoggerService.Gravar("Serviço de produto iniciado");

            if (preco > 10000)
            {
                LoggerService.Gravar("Preço fora da faixa permitida");
                return null;
            }

            var produto = ProdutoRepository.Inserir(nome, preco);

            if (produto != null)
            {
                MensageriaService.Enviar(produto);

                return produto;
            }

            return null;
        }
    }
}
