using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Messages
{
    public class ProdutoDto
    {
        public Produto Produto { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public ProdutoDto(Produto produto, bool sucesso, string mensagem) {
            Produto = produto;
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public ProdutoDto(bool sucesso, string mensagem) {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }    
}
