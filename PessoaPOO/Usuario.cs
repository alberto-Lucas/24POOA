namespace PessoaPOO
{
    public class Usuario
    {
        public Pessoa Pessoa { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string NomeEmail
        {
            get
            {
                return Pessoa.CPFNome + " - " + Email;
            }
        }
    }
}
