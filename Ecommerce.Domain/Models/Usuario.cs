namespace Ecommerce.Domain.Models
{
    public class Usuario
    {
        public string Email { get; }
        public string Senha { get; }

        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;            
        }
    }
}
