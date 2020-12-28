using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Produto Inserir(string nome, decimal preco)
        {
            // rotina de persistencia aqui
            return new Produto(nome, preco);
        }
    }
}
