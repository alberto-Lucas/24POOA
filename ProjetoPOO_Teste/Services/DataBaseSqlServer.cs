using System.Data.SqlClient;

namespace ProjetoPOO_Teste.Services
{
    public class DataBaseSqlServer
    {
        //Métodos privado que cria nova conexão com o banco
        private SqlConnection CriarConexao()
        {
            SqlConnection conexao = new SqlConnection();

            conexao.ConnectionString =
                "Data Source=.\\SQLExpress;" +
                "Initial Catalog=pooCamadas;" +
                "Integrated Security=SSPI;" +
                "User Instance = false;";

            conexao.Open();
            return conexao;
        }

        public SqlConnection GetConnection()
        {
            return CriarConexao();
        }
    }
}
