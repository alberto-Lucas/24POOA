using System;
using System.Windows.Forms;

namespace PessoaPOO
{
    public partial class frmPrincipal : Form
    {
        //Primeiramente como estamos utilizando apenas classes de objeto
        //É preciso fazer desta forma levar o objeto pra e praca
        //para nao perder o apontamento de memoria da instancia
        //quando estiver com o banco de dados conectado
        //ficara mais facil a manipulação dos dados, pois
        //sera possivel realizar o insert e consultas de qualquer lugar 
        //nao dependenra mais do apontamento de memoria

        //---------------------------------------------------------------------
        //Criei essa tela nova reunir a tela criada na aula do dia 29/08/2024
        //Nessa tela o botão PessoaPOO ira exibir a tela criada em sala
        //onde toda a parte de criação, listagem e exibição do registro Usuario
        //é realizado tudo na mesma tela
        //---------------------------------------------------------------------
        //Porém criei o botão PessoaPOOModificado para apresentar de uma forma
        //mais usual essa manipulação de registro a separando em 3 telas
        //1 Tela somente para listagem de registros
        //1 Tela somente para o cadastro do registro
        //1 Tela somente para exibição do registro selecionado
        //---------------------------------------------------------------------
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnPessoaPOO_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void btnPessoaPOOModificado_Click(object sender, EventArgs e)
        {
            frmUsuarioPOOModificado frm = new frmUsuarioPOOModificado();
            frm.ShowDialog();
        }
    }
}
