using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorDeTarefas
{
    internal class TarefaRepository
    {
        public void AdicionarTarefa(Tarefa tarefa)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string query = "INSERT INTO Tarefas (Titulo, Descricao, DataVencimento, Concluida) VALUES (@titulo, @descricao, @dataVencimento, @concluida)";
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@titulo", tarefa.Titulo);
                    comando.Parameters.AddWithValue("@descricao", tarefa.Descricao);
                    comando.Parameters.AddWithValue("@dataVencimento", tarefa.DataVencimento);
                    comando.Parameters.AddWithValue("@concluida", tarefa.Concluida);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ListarTarefas()
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string query = "SELECT * FROM Tarefas";
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(query, conexao))
                {
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            int id = leitor.GetInt32("Id");
                            string titulo = leitor.GetString("Titulo");
                            string descricao = leitor.GetString("Descricao");
                            DateTime dataVencimento = leitor.GetDateTime("DataVencimento");
                            bool concluida = leitor.GetBoolean("Concluida");
                            Console.WriteLine($"Id: {id}, Titulo: {titulo}, Descricao: {descricao}, Data de Vencimento: {dataVencimento}, Concluida: {concluida}");
                        }
                    }
                }
            }
        }
    }
}
