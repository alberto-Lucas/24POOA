using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PessoaPOO
{
    public partial class Form1 : Form
    {
        //Criar uma instancia global
        //para acessar a classe de
        //manipulção
        UsuarioExecucao usuarioExecucao =
            new UsuarioExecucao();
        public Form1()
        {
            InitializeComponent();
        }

        private void AdicionarUsuario()
        {
            //Variaveis auxiliares para cada
            //campo
            string cpf, nome, email, senha;
            DateTime dtNascimento;

            //Iremos popular as variaveis
            //de acordo as informações
            //inseridas pelo usuario final
            nome = txtNome.Text;
            cpf = txtCPF.Text;
            email = txtEmail.Text;
            senha = txtSenha.Text;
            dtNascimento = dtpDtNascimento.Value;

            //Validação simples
            //apenas de exemplo

            if (string.IsNullOrEmpty(cpf) &&
                string.IsNullOrEmpty(nome))
                return; //aborta a execução

            //Criamos a instancia das classes
            Usuario usuario = new Usuario();
            Pessoa  pessoa = new Pessoa();

            //Popular o objeto pessoa
            pessoa.Nome = nome;
            pessoa.CPF = cpf;
            pessoa.DtNascimento = dtNascimento;

            //Popular objeto usuario
            usuario.Email = email;
            usuario.Senha = senha;
            usuario.Pessoa = pessoa;

            //Aqui finalizar a atribuição de valores
            //Agora precisamos manipular os registro
            usuarioExecucao.Adicionar(usuario);
            //Nesse momento o objeto usuario
            //ja foi adicionado a lista]

            //Atualizar a listBox para exibir
            //os registros
            AtualizarListaUsuarios();

            //Após inserir os dados
            //Vamos limpar os campos
            txtCPF.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            dtpDtNascimento.Value = DateTime.Now;
        }

        //Método atualizar o LisBox
        private void AtualizarListaUsuarios()
        {
            //Limpar o listBox
            lsbUsuarios.DataSource = null;
            //Vou popular a ListBox com a 
            //listaUsuarios
            lsbUsuarios.DataSource =
                usuarioExecucao.ListarUsuarios();

            //Definir qual informação será exibida
            lsbUsuarios.DisplayMember =  "NomeEmail";
        }

        //Método para remover um registro da lista
        private void RemoverUsuario()
        {
            //Primeiro identificar o registro
            //selecionado na listBox
            Usuario usuarioSelecionado =
                lsbUsuarios.SelectedItem as Usuario;

            //Após coletor o objeto
            //Preciso validar se está null
            if(usuarioSelecionado != null)
            {
                //Se for diferente de nullo
                //posso remove-lo
                usuarioExecucao.
                    Remover(usuarioSelecionado);

                AtualizarListaUsuarios();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarUsuario();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverUsuario();
        }

        //Método para exibir os detalhes 
        //do registro selecionado
        private void ExibirUsuario()
        {
            Usuario usuarioSelecionado =
                lsbUsuarios.SelectedItem as Usuario;

            if(usuarioSelecionado != null)
            {
                txtVisCPF.Text =
                    usuarioSelecionado.Pessoa.CPF;
                txtVisNome.Text =
                    usuarioSelecionado.Pessoa.Nome;
                txtVisDtNascimento.Text =
                    usuarioSelecionado.Pessoa.
                        DtNascimento.ToShortDateString();
                txtVisIdade.Text =
                    usuarioSelecionado.Pessoa.
                        Idade.ToString();
                txtVisEmail.Text =
                    usuarioSelecionado.Email;
                txtVisSenha.Text =
                    usuarioSelecionado.Senha;

            }
        }

        private void lsbUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExibirUsuario();    
        }
    }
}
