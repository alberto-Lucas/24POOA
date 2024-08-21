using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePOO
{
    public partial class Form1 : Form
    {
        private class Pessoa
        {
            //prop(atalho) pressionar TAB 2 vezes
            //Atributo é definido por
            //Acesso: plublic ou private
            //tipo de dados: string, int, bool...
            //nome do atributo: Nome, CPF, ...
            //Get/Set: leitura e gravação
            public string Nome { get; set; }
            public string CPF { get; set; }
            public DateTime DtNascimento { get; set; }

            //Criar um construtor para definir
            //um valor padrão para cada atributo
            public Pessoa()
            {
                Nome = "Desconhecido";
                CPF = "00000000000";
                DtNascimento = DateTime.Now;
            }

            //Criamos um método
            //que retorna uma mensagem de boas vindas
            //de acordo como valor do atributo Nome
            public string GetBoasVindas()
            {
                return "Boas vindas," + Nome;
            }

            //Criar uma propriedade somente leitura
            //q ira retornar a concatenação
            //do CPF com o valor do atributo Nome
            public string CPFNome
            {
                get
                {
                    return CPF + " - " + Nome.ToUpper();
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        Pessoa pessoaBkp = new Pessoa();

        private void button1_Click(object sender, EventArgs e)
        {
            //Criar uma instancia da classe Pessoa
            //ou seja vamos alocar a classe em memoria
            Pessoa instancia = new Pessoa();
            //neste a variavel "instancia" recebe o endereço
            //da classe Pessoa que foi alocada em memoria
            //portante "instancia" passa a ser um 
            //objeto do tipo Pessoa
            instancia.Nome = txtNome.Text;
            instancia.CPF = txtCPF.Text;
            instancia.DtNascimento = dtpDtNascimento.Value;

            pessoaBkp = instancia;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            txtVisNome.Text = pessoaBkp.Nome;
            txtVisCPF.Text = pessoaBkp.CPF;
            txtVisDtNascimento.Text =
                pessoaBkp.DtNascimento.
                    ToShortDateString();

            lblBoasVindas.Text = 
                pessoaBkp.GetBoasVindas();

            lblCPFNome.Text = pessoaBkp.CPFNome;
        }
    }

}
