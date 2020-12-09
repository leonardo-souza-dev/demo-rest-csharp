using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProdutoService
    {
        Produto Inserir(string nome, decimal preco);
        Produto Obter(int id);
    }
}
