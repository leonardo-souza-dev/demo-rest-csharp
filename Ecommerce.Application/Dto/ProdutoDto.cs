using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Messages
{
    public record ProdutoDto(Produto Produto, bool Sucesso, string Mensagem);
}
