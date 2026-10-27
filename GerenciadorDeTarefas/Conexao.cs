using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace GerenciadorDeTarefas
{
    internal class Conexao
    {
        public static MySqlConnection ObterConexao()
        {
            string connectionString = "server=localhost;database=GerenciadorDeTarefas;user=root;password=Mamada69@;";
            MySqlConnection conexao = new MySqlConnection(connectionString);
            conexao.Open();
            return conexao;
        }
    }
}
