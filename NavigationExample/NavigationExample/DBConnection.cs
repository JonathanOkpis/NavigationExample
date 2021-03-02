using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient; //DEPENDÊNCIA DA INSTALAÇÃO DESTE NUGET
using System.Text;

namespace NavigationExample
{
    
    public class DBConnection
    {
        #region CONEXAO
        //AQUI VOCÊ INSERE A CONEXÃO COM O BANCO DE DADOS
        public static SqlConnection Conn()
        {
            string connectionString = string.Empty;
            connectionString += "Server=INSTANCE_NAME;";
            connectionString += "Port=PORT;";
            connectionString += "User Id=USERNAME;";
            connectionString += "Password=PASSWORD;";
            connectionString += "Database=DATABASE_NAME";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;

        }
        #endregion

        #region EXEMPLO CRIACAO SQL
        //ALGUNS EXEMPLOS DE CRIAÇÃO DE SQL
        public class CriaSQL
        {
            //EXEMPLO SELECT
            public void CriaSQLConsulta()
            {
                try
                {
                    using (SqlConnection conn = Conn())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM foo_bar", conn);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //INSERE ONDE QUISER AS INFORMAÇÕES CONTIDAS NO SELECT
                            }
                        }
                       
                     }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            //EXEMPLO INSERT (OPERAÇÕES COMO UPDATE, ALTER TABLE, ALTER COLUMN SE BASEIAM NA MESMA)
            public async void CriaSQLInsert()
            {
                try
                {
                    using (SqlConnection conn = Conn())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO foo_bar VALUES ('value')", conn);
                        await cmd.ExecuteNonQueryAsync();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

        }
        #endregion
    }
}
