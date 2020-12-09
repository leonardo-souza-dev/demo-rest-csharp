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

        public Produto Obter(int id)
        {
            return new Produto(id, "TV", 1999);
        }
    }
}
