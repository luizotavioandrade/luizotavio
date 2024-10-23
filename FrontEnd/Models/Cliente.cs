using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Username é obrigatório.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome} - Email: {Email}"; // Removed Senha for security
        }

        // Método para hash da senha (pseudo-código, substitua pela lógica de hash real)
        public string GerarHashSenha(string senha)
        {
            // Implementar a lógica de hash da senha aqui (ex: usando BCrypt ou SHA256)
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senha)); // Placeholder
        }

        // Método opcional para validar o formato do email
        public bool ValidarEmail(string email)
        {
            var emailAddress = new EmailAddressAttribute();
            return emailAddress.IsValid(email);
        }

        // Método para realizar login do cliente
        public bool FazerLogin(string username, string senha)
        {
            return Username.Equals(username, StringComparison.OrdinalIgnoreCase) && Senha.Equals(senha);
        }
    }
}
