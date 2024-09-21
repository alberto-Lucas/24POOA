using ProjetoPOO_Teste.Controller;
using ProjetoPOO_Teste.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPOO_Teste
{
    public partial class Form1 : Form
    {
        ClienteController clienteController = new ClienteController();
        public Form1()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = false;
        }

        private Cliente GetCliente()
        {
            Cliente cliente = new Cliente();

            cliente.Id_Cliente = int.Parse(txtID.Text);
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.RG = "12313";
            cliente.Telefone = "2231320";
            cliente.DATA_NASCIMENTO = DateTime.Now;

            return cliente;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            clienteController.Inserir(GetCliente());
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            clienteController.Atualizar(GetCliente());
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            clienteController.Deletar(GetCliente());
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = clienteController.GetAll();
        }
    }
}
