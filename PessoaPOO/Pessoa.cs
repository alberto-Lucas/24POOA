using System;

namespace PessoaPOO
{
    public class Pessoa
    {
        //prop e apertar TAB duas vezes
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string CPF { get; set; }

        //Propriedades somente leitura

        public string CPFNome
        {
            get
            {
                return CPF + " - " + Nome;
            }
        }

        public int Idade
        {
            get
            {
                //Now usado para retornar
                //Data e Hora atual do computador
                DateTime dataAtual = DateTime.Now;
                int idade = dataAtual.Year - DtNascimento.Year;

                if(dataAtual.Month < DtNascimento.Month ||
                    (dataAtual.Month == DtNascimento.Month  &&
                    dataAtual.Day < DtNascimento.Day))
                {
                    idade--;
                }

                return idade;
            }
        }
    }
}
