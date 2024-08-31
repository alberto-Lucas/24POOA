using System;
using System.Windows.Forms;

namespace PessoaPOO
{
    public partial class frmUsuarioPOOModificado : Form
    {
        //---------------------------------------------------------------------
        //Criamos a instancia global da UsuarioExecucao
        //assim podemos acessa o conteudo dela de qualquer parte 
        //do sistema sem perder o apontamento de memoria
        //como estamos manipulando o objeto Usuario direto
        //e somente ele, é nescessario criar as instancia globais
        //para que não se perca os apontamentos de memoria
        //ao utilizar conexao com banco de dados 
        //a instancia seram criadas conforme nescessario em 
        //cada metodo, nao iremos usar mais isntancia globais desta forma
        private UsuarioExecucao usuarioExecucao = new UsuarioExecucao();

        public frmUsuarioPOOModificado()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------
        //--PESQUISAR--------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //---------------------------------------------------------------------
            //Primeira coisa pra realizar o processo de pesquisa
            //Preciso criar o metodo de presquisa na UsuarioExecucao
            PesquisarUsuario(txtPesquisa.Text);
        }

        //---------------------------------------------------------------------
        //metodo responsavel por realizar a pesquisa
        private void PesquisarUsuario(string valor)
        {
            //---------------------------------------------------------------------
            //usaremos este meotodo PesquisarUsuario()
            //como se fosse o meotdo AtualizarListaUsuarios()
            //para isso foir preciso criar o meotod Pesquisar na UsuarioExecucao

            //---------------------------------------------------------------------
            //Primeiro limpamos a listabox
            //Chamamos o metodo pesquisa da UsuarioExecucao passando
            //o valor digitado por parametro
            //E definimos qual atributos sera exibido em tela
            //Esse atributo é somente para exibição visual
            lsbUsuarios.DataSource = null;
            lsbUsuarios.DataSource = usuarioExecucao.Pesquisar(valor);
            lsbUsuarios.DisplayMember = "NomeEmail";
        }

        //-------------------------------------------------------------------------------------------------------------
        //--CADASTRAR--------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadUsuario frm = new frmCadUsuario();
            //---------------------------------------------------------------------
            //iremos chamar a tela de cadadstro como ShowDialog()
            //pois iremos receber um retorno de confirmação dela
            //No caso o retorno OK
            //para receber retornos de chamadas de tela é precisso
            //usar o ShowDialog(), q neste caso esperamos receber 
            //um OK como retorno identificamos que foi criado 
            //o Objeto Usuario e o mesmo pode ser salvo
            DialogResult dialogResult = frm.ShowDialog();

            //---------------------------------------------------------------------
            //Verificamos se o retorno da tela foi OK
            if (dialogResult == DialogResult.OK)
            {
                //---------------------------------------------------------------------
                //Acessamos a instancia da Objeto Usuario que foi criado
                //como publico aqui é o exemplo de acesso, por isso 
                //foi preciso criar de forma global e publica a instancia
                //Depois fo objeto Usuario populado com informações
                //podemos adicionar ele na listagem o passando por parametro
                //para o meotod aidiconar da UsuarioExecucao
                usuarioExecucao.Adicionar(frm.usuario);
            }

            //---------------------------------------------------------------------
            //chamamos o método pesquisar passando o parametro vazio
            //lembrando que a realizar o filtro na lista, se o parametro
            //estiver vazio é retorno todos os registros
            //como o método foi criado com parametro sou obrigado a passar
            //um parametro mesmo que ele seja vazio
            PesquisarUsuario("");
        }

        //-------------------------------------------------------------------------------------------------------------
        //--VISUALIZAR-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            ExibirUsuario();
        }

        private void ExibirUsuario()
        {
            //---------------------------------------------------------------------
            //Criamos uma variavel do tipo Usuario que ira receber
            //o apontamento de memoria do objeto selecionado no listBox
            //Eu identifico o registro selecionado pelo SelectedItem
            //e utilizo "as" para converter o item do listBox para um
            //objeto no o Usuario entao seria
            //lsbUsuarios.SelectedItem as Usuario
            //converta o item selecionado para o objeto Usuario
            //e atribua esse objeto Usuario a variavel usuarioSelecionado
            Usuario usuarioSelecionado = lsbUsuarios.SelectedItem as Usuario;

            //---------------------------------------------------------------------
            //Verificamos se a variavel não esta nulla usuarioSelecionado
            //ou seja se a conversão foi realizada corretamente
            if (usuarioSelecionado != null)
            {
                //---------------------------------------------------------------------
                //Criamos a instancia para chamar a tela de exibição
                //Aqui é um ponto importante pois como eu criei um
                //parametro na tela ExibiUsuario que receba o obejto Usuario
                //eu preciso passar esse parametro agora no momento da instancia
                frmExibeUsuario frm = new frmExibeUsuario(usuarioSelecionado);
                frm.ShowDialog();
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        //--REMOVER----------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
        private void RemoverUsuario()
        {
            //---------------------------------------------------------------------
            //Criamos uma variavel do tipo Usuario que ira receber
            //o apontamento de memoria do objeto selecionado no listBox
            //Eu identifico o registro selecionado pelo SelectedItem
            //e utilizo "as" para converter o item do listBox para um
            //objeto no o Usuario entao seria
            //lsbUsuarios.SelectedItem as Usuario
            //converta o item selecionado para o objeto Usuario
            //e atribua esse objeto Usuario a variavel usuarioSelecionado
            Usuario usuarioSelecionado = lsbUsuarios.SelectedItem as Usuario;

            //---------------------------------------------------------------------
            //Verificamos se a variavel não esta nulla usuarioSelecionado
            //ou seja se a conversão foi realizada corretamente
            if (usuarioSelecionado != null)
            {
                //---------------------------------------------------------------------
                //passa a variavel usuarioSelecionado via parametro 
                //para o metodo Remover na UsuarioExecucao
                //contendo o apontamento de memoria do registro
                usuarioExecucao.Remover(usuarioSelecionado);

                //---------------------------------------------------------------------
                //chamamos o método pesquisar passando o parametro vazio
                //lembrando que a realizar o filtro na lista, se o parametro
                //estiver vazio é retorno todos os registros
                //como o método foi criado com parametro sou obrigado a passar
                //um parametro mesmo que ele seja vazio
                PesquisarUsuario("");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverUsuario();
        }
    }
}
