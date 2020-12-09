using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Produto Inserir(string nome, decimal preco);
        Produto Obter(int id);
    }
}