using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaPOO
{
    //Primeiro passo é deixa a classe Publicc
    public class Pessoa
    {
        //Definir os atributos
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DtNascimento { get; set; }

        public string CPFNome 
        {
            get
            {
                return CPF + " - " + Nome;
            }
        }

        //Atributo para retornar a Idade
        public int Idade
        {
            get
            {
                //Recuperar a data atual
                DateTime dtAtual = DateTime.Now;
                int idade =
                    dtAtual.Year - DtNascimento.Year;

                if(dtAtual.Month < DtNascimento.Month ||
                    (dtAtual.Month == DtNascimento.Month &&
                    dtAtual.Day < DtNascimento.Day))
                {
                    idade--;
                }

                return idade;
            }
        }
    }
}
