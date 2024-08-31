using System;
using System.Windows.Forms;

namespace PessoaPOO
{
    public partial class frmCadUsuario : Form
    {
        //---------------------------------------------------------------------
        //Crio uma instancia global e publica para o meu objeto Usuario
        //Importante q ela seja public para que seja acessada de outras 
        //partes do sistema
        //Ou seja esta tela nao será efetuada o cadastro em si, mas sim
        //irá popular os dados no objeto, e esse obejto sera acdessado
        //em outra tela para gravar os dados na nossa lista
        public Usuario usuario = new Usuario();
        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AdicionarUsuario();
        }

        private void AdicionarUsuario()
        {
            //---------------------------------------------------------------------
            //Crio variaveis locais para armazenar os dados digitados na tela
            //Importante utilizar essas variaveis auxiliares, para deixar
            //o codigo mais limpo e facil de manipular, principalmente 
            //nas validações
            string nome, cpf, email, senha;
            DateTime dtNascimento;

            //---------------------------------------------------------------------
            //Atribuindo os dados digitados as variaveis locais
            nome = txtNome.Text;
            cpf = txtCPF.Text;
            dtNascimento = dtpDtNascimento.Value;
            email = txtEmail.Text;
            senha = txtSenha.Text;

            //---------------------------------------------------------------------
            //Validação simples apenas de 2 campos para exemplo
            //Validando apenas se o campos não esta em branco ou nullo
            if (!String.IsNullOrEmpty(nome) || !String.IsNullOrEmpty(cpf))
            {
                //---------------------------------------------------------------------
                //Apesar de maminuplar o objeto Usuario 
                //É preciso instanciar o objeto Pessoa, para receber 
                //as informações e gerar um apontamente em memoria desses dados
                Pessoa pessoa = new Pessoa();

                //---------------------------------------------------------------------
                //Populando somente o Objeto Pessoa nesse momento
                pessoa.Nome = nome;
                pessoa.CPF = cpf;
                pessoa.DtNascimento = dtNascimento;

                //---------------------------------------------------------------------
                //Aqui vem o pulo do gato
                //o objeto Usuario possui um atributo pessoa
                //Entao eu passo a minha instancia Pessoa, para o atributo do Usuario
                //Dessa forma estou levando o apentamento de memoria para dentro do Usuario
                //Assim o objeto Usuario recebe todas os dados do objeto Pessoa
                usuario.Pessoa = pessoa;
                usuario.Email = email;
                usuario.Senha = senha;

                //---------------------------------------------------------------------
                //Este comando serve para fechar tela e retorna um ok de onde ela foi chamada
                //Isso é importante para ao fechara a tela eu avisar que eu posso gravar os dados
                //na listagem
                //pois caso eu cancele ou feche a tela no X eu nao tente gravar dados vazios
                //Assim eu falou olha ta tudo ok, pode gravar os dados
                //Esse comando só vai funcionar se eu chamar essa tela aqui usando o ShowDialog()
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
