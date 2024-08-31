using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaPOO
{
    public class Usuario
    {
        //Usuario tambem é uma Pessoa
        //Portanto usuario possui um atributo 
        //Pessoa

        public Pessoa Pessoa { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string NomeEmail
        {
            get
            {
                return 
                    Pessoa.CPFNome + " - " + Email;
            }
        }
    }
}
