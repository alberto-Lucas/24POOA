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
    public partial class frmVisBrinquedo : Form
    {
        public frmVisBrinquedo(Brinquedo brinquedo)
        {
            InitializeComponent();
            txtCodBarras.Text = 
                brinquedo.Produto.CodBarras;
            txtDesc.Text = 
                brinquedo.Produto.Descricao;
            txtPreco.Text =
                brinquedo.Produto.Preco.ToString();
            txtCategoria.Text =
                brinquedo.Categoria;
            txtIdadeMin.Text =
                brinquedo.IdadeMin.ToString();
            txtFabricante.Text =
                brinquedo.Produto.Fabricante.CNPJNome;
        }
    }
}
