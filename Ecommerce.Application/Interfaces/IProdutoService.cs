using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces
{
    public interface IProdutoService
    {
        Produto Inserir(string nome, decimal preco);
    }
}
