namespace Ecommerce.Domain.Models
{
    public class Produto
    {
        public int Id { get; }
        public string Nome { get; }
        public decimal Preco { get; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public Produto(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }
}
