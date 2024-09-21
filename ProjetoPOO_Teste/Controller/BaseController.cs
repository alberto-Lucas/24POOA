using ProjetoPOO_Teste.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace ProjetoPOO_Teste.Controller
{
    public class BaseController<T> where T : class, new()
    {
        private DataBaseSqlServer db = new DataBaseSqlServer();
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        public int ExecutarManipulacao(CommandType commandType, string query)
        {
            try
            {
                SqlConnection sqlConnection = db.GetConnection();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = query;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));

                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar o comando no banco de dados: " + ex.Message);
            }
        }

        private int Manipular(T entidade, string tableName, string primaryKeyName)
        {
            LimparParametros();

            Type type = entidade.GetType();
            PropertyInfo[] properties = type.GetProperties();

            var columns = properties
                .Where(p => !p.GetCustomAttributes(typeof(NotMappedAttribute), true).Any() &&
                            !p.GetCustomAttributes(typeof(KeyAttribute), true).Any())
                .ToList();

            foreach (var prop in columns)
            {
                AdicionarParametros("@" + prop.Name, prop.GetValue(entidade));
            }

            string query = "";

            if (string.IsNullOrEmpty(primaryKeyName))
            {
                string columnNames = string.Join(", ", columns.Select(p => p.Name));
                string parameterNames = string.Join(", ", columns.Select(p => "@" + p.Name));

                query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";
            }
            else
            {
                string updateClause = string.Join(", ", columns.Select(p => $"{p.Name} = @{p.Name}"));
                object primaryKeyValue = type.GetProperty(primaryKeyName).GetValue(entidade);
                AdicionarParametros("@" + primaryKeyName, primaryKeyValue);

                query = $"UPDATE {tableName} SET {updateClause} WHERE {primaryKeyName} = @{primaryKeyName}";

            }

            return ExecutarManipulacao(CommandType.Text, query);
        }

        public int Inserir(T entidade, string tableName)
        {
            return Manipular(entidade, tableName, null);
        }

        public int Atualizar(T entidade, string tableName, string primaryKeyName)
        {
            return Manipular(entidade, tableName, primaryKeyName);
        }

        public int Deletar(string tableName, string primaryKeyName, object primaryKeyValue)
        {
            LimparParametros();

            AdicionarParametros("@" + primaryKeyName, primaryKeyValue);

            string query = $"DELETE FROM {tableName} WHERE {primaryKeyName} = @{primaryKeyName}";
            return ExecutarManipulacao(CommandType.Text, query);
        }

        private DataTable Consultar(string tableName, string filtro)
        {
            SqlConnection sqlConnection = db.GetConnection();

            string query = $"SELECT * FROM {tableName} ";

            if (!string.IsNullOrEmpty(filtro))
                query += $"WHERE {filtro}";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable ConsultarTodos(string tableName)
        {
            return Consultar(tableName, null);
        }

        public DataTable ConsultarComFiltro(string tableName, string filtro)
        {
            return Consultar(tableName, filtro);
        }

        public List<T> ConverterDataTableParaModelos(DataTable dataTable)
        {
            List<T> lista = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T modelo = new T();
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (PropertyInfo property in properties)
                    if (dataTable.Columns.Contains(property.Name))
                        if (row[property.Name] != DBNull.Value)
                            property.SetValue(modelo, Convert.ChangeType(row[property.Name], property.PropertyType));

                lista.Add(modelo);
            }

            return lista;
        }
    }
}
