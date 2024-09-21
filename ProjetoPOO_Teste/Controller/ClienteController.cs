using ProjetoPOO_Teste.Models;
using ProjetoPOO_Teste.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoPOO_Teste.Controller
{
    public class ClienteController
    {
        private BaseController<Cliente> repository = new BaseController<Cliente>();

        public int Inserir(Cliente cliente)
        {
            return repository.Inserir(cliente, "cliente");
        }

        public int Atualizar(Cliente cliente)
        {
            return repository.Atualizar(cliente, "cliente", "Id_Cliente");
        }

        public int Deletar(Cliente cliente)
        {
            return repository.Deletar("cliente", "Id_Cliente", cliente.Id_Cliente);
        }

        public DataTable ConsultarTodos()
        {
            return repository.ConsultarTodos("cliente");
        }

        public DataTable ConsultarComFiltro(string filtro)
        {
            return repository.ConsultarComFiltro("cliente", filtro);
        }

        public List<Cliente> GetAll()
        {
            DataTable dataTable = ConsultarTodos();
            return repository.ConverterDataTableParaModelos(dataTable);
        }
    }
}
