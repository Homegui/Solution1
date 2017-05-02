using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;



namespace AcessoBanco
{
    public class AcessoBanco
    {
        //Criar Conexão
        public static SqlConnection Conectar()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = @"NOTESP344\NOTESP";
            sb.InitialCatalog = "Kanino";
            sb.UserID = "sa";
            sb.Password = "Allen@2014";

            SqlConnection cn = new SqlConnection(sb.ConnectionString);
            cn.Open();


           

            return cn;
        }

        //Parametro que vão ao banco
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;
        
        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Persistencia - Inserir , Alterar, Excluir

        public object ExecutarManipulacao(CommandType commandType,string nomeProcouTextoSQL)
        {
            try
            {
                SqlConnection sqlConnection = Conectar();
                sqlConnection.Open();

                SqlCommand sqlComando = sqlConnection.CreateCommand();
                sqlComando.CommandType = commandType;
                sqlComando.CommandText = nomeProcouTextoSQL;
                sqlComando.CommandTimeout = 600;

                //adicionar parametros
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlComando.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
               
                return sqlComando.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 

            }

        }

        //Consultar registrosdo Banco
        public DataTable ExecutarConsulta(CommandType commandType, string nomeProcouTextoSQL)

        {
            try
            {
                SqlConnection sqlConnection = Conectar();
                sqlConnection.Open();

                SqlCommand sqlComando = sqlConnection.CreateCommand();
                sqlComando.CommandType = commandType;
                sqlComando.CommandText = nomeProcouTextoSQL;
                sqlComando.CommandTimeout = 600;

                //adicionar parametros
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlComando.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                //Criar adaptador
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlComando);
                //Criar tabela vazia
                DataTable dataTable = new DataTable();
                //Enviar Comando para buscar dados
                sqlAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}
