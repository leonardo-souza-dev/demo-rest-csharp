namespace Ecommerce.Domain.Models
{
    public class Produto
    {
        public string Nome { get;  }
        public decimal Preco { get;  }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}
