using System.Windows.Forms;

namespace PessoaPOO
{
    public partial class frmExibeUsuario : Form
    {
        //---------------------------------------------------------------------
        //Crio um instancia global para manipular o obejto
        Usuario usuarioExibicao;

        //---------------------------------------------------------------------
        //No construtor da tela eu recebo por parametro
        //o objeto Usuario, ele ja vim com as informações 
        //populadas do usuario selecionado no listBox
        public frmExibeUsuario(Usuario usuario)
        {
            InitializeComponent();
            //---------------------------------------------------------------------
            //Neste caso estou recebendo o objeto por parametro 
            //E passando o objeto tbm para nossa instancia global
            usuarioExibicao = usuario;

            //---------------------------------------------------------------------
            //Chamo o metodo para exibiro o usuario
            ExibirUsuario();
        }

        //---------------------------------------------------------------------
        //Crio o método para exibir os usuario
        private void ExibirUsuario()
        {
            //---------------------------------------------------------------------
            //Recupero os dados do usuario atraves do
            //objeto da instancia global criada acima
            txtExibeCPF.Text            = usuarioExibicao.Pessoa.CPF;
            txtExibeNome.Text           = usuarioExibicao.Pessoa.Nome;
            txtExibeDtNascimento.Text   = usuarioExibicao.Pessoa.DtNascimento.ToShortDateString();
            txtExibeIdade.Text          = usuarioExibicao.Pessoa.Idade.ToString();
            txtExibeEmail.Text          = usuarioExibicao.Email;
            txtExibeSenha.Text          = usuarioExibicao.Senha;
        }
    }
}
