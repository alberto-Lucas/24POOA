using System;
using System.Windows.Forms;

namespace PessoaPOO
{
    public partial class Form1 : Form
    {
        private UsuarioExecucao usuarioExecucao =
            new UsuarioExecucao();
        public Form1()
        {
            InitializeComponent();
        }

        private void AdicionarUsuario()
        {
            string cpf, nome, email, senha;
            DateTime dtNascimento;

            nome = txtNome.Text;
            cpf = txtCPF.Text;
            dtNascimento = dtpDtNascimento.Value;
            email = txtEmail.Text;
            senha = txtSenha.Text;

            //Validação
            if(!string.IsNullOrEmpty(cpf) &&
                !string.IsNullOrEmpty(nome))
            {
                Usuario usuario = new Usuario();
                Pessoa pessoa = new Pessoa();

                pessoa.Nome = nome;
                pessoa.CPF = cpf;
                pessoa.DtNascimento = dtNascimento;

                //Atribuo os valores do Objeto Pessoa
                //Ao objeto Usuario
                usuario.Pessoa = pessoa;
                usuario.Email = email;
                usuario.Senha = senha;

                usuarioExecucao.Adicionar(usuario);

                AtualizarListaUsuarios();

                txtCPF.Clear();
                txtNome.Clear();
                dtpDtNascimento.Value = DateTime.Now;
                txtEmail.Clear();
                txtSenha.Clear();
            }
        }

        private void RemoverUsuario()
        {
            Usuario usuarioSelecionado =
                lsbUsuarios.SelectedItem as Usuario;

            if(usuarioExecucao != null)
            {
                usuarioExecucao.Remover(usuarioSelecionado);
                AtualizarListaUsuarios();
            }
        }

        private void AtualizarListaUsuarios()
        {
            lsbUsuarios.DataSource = null;
            lsbUsuarios.DataSource = 
                usuarioExecucao.ListarUsuarios();
            //Proriedade NomeEmail do objeto Usuario
            lsbUsuarios.DisplayMember = "NomeEmail";
        }

        private void ExibirUsuario()
        {
            Usuario usuarioSelecionado =
                lsbUsuarios.SelectedItem as Usuario;

            if(usuarioSelecionado != null)
            {
                txtExibeCPF.Text = usuarioSelecionado.Pessoa.CPF;
                txtExibeNome.Text = usuarioSelecionado.Pessoa.Nome;
                txtExibeDtNascimento.Text =
                    usuarioSelecionado.Pessoa.
                        DtNascimento.ToShortDateString();
                txtExibeIdade.Text = usuarioSelecionado.Pessoa.
                                        Idade.ToString();
                txtExibeEmail.Text = usuarioSelecionado.Email;
                txtExibeSenha.Text = usuarioSelecionado.Senha;
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

        private void lsbUsuarios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExibirUsuario();
        }
    }
}
