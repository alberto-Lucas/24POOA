using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrinquedoPOO
{
    public partial class frmCadBrinquedo : Form
    {
        BrinquedoExecucao brinquedoExec = 
            new BrinquedoExecucao();
        public frmCadBrinquedo()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Fabricante fabricante = new Fabricante();
            Produto produto = new Produto();
            Brinquedo brinquedo = new Brinquedo();

            fabricante.CNPJ = txtCNPJ.Text;
            fabricante.Nome = txtNome.Text;

            produto.CodBarras = txtCodBarras.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Preco = 
                decimal.Parse(txtPreco.Text);
            //Vincular o Fabricante com o Produto
            produto.Fabricante = fabricante;

            brinquedo.IdadeMin = 
                int.Parse(txtIdadeMin.Text);
            brinquedo.Categoria = txtCategoria.Text;
            //Vincular o Produto com o Brinquedo
            brinquedo.Produto = produto;
            //Adicionamos o Objeto Brinquedo na lista
            brinquedoExec.Adicionar(brinquedo);

            AtualizarLista(); 

            txtCNPJ.Clear();
            txtNome.Clear();
            txtCodBarras.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtIdadeMin.Clear();
            txtCategoria.Clear();
        }

        private void AtualizarLista()
        {
            //resetar a listabox
            lstBrinquedos.DataSource = null;
            //Recupar a lista de brinquedos
            //Atribuir a lista a nossa listbox
            lstBrinquedos.DataSource =
                brinquedoExec.Listar();
            //Definir qual campo sera exibido
            lstBrinquedos.DisplayMember =
                "CodBarrasDescCatFabricante";
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            Brinquedo brinqueSelecionado 
                = lstBrinquedos.SelectedItem 
                    as Brinquedo;

            if(brinqueSelecionado != null)
            {
                brinquedoExec.Remover(brinqueSelecionado);
                AtualizarLista();
            }
        }
    }
}
