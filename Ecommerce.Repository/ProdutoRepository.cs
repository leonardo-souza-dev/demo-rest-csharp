using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Produto Inserir(string nome, decimal preco) =>
            new Produto(nome, preco);
    }
}
