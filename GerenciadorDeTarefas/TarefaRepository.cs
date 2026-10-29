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

        public List<Tarefa> ListarTarefas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            using (var conexao = Conexao.ObterConexao())
            {
                string query = "SELECT * FROM Tarefas";

                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(query, conexao))
                {
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Tarefa tarefa = new Tarefa
                            {
                                Id = leitor.GetInt32("Id"),
                                Titulo = leitor.GetString("Titulo"),
                                Descricao = leitor.IsDBNull(leitor.GetOrdinal("Descricao"))
                                ? null
                                : leitor.GetString("Descricao"),
                                DataVencimento = leitor.GetDateTime("DataVencimento"),
                                Concluida = leitor.GetBoolean("Concluida")
                            };

                            tarefas.Add(tarefa);
                        }
                    }
                }
            }

            return tarefas;
        }


        public void AtualizarTarefa(Tarefa tarefa)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string query = "UPDATE Tarefas SET Titulo = @titulo, Descricao = @descricao, DataVencimento = @dataVencimento, Concluida = @concluida WHERE Id = @id";
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@titulo", tarefa.Titulo);
                    comando.Parameters.AddWithValue("@descricao", tarefa.Descricao);
                    comando.Parameters.AddWithValue("@dataVencimento", tarefa.DataVencimento);
                    comando.Parameters.AddWithValue("@concluida", tarefa.Concluida);
                    comando.Parameters.AddWithValue("@id", tarefa.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }


        public void ExcluirTarefa(int id)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                string query = "DELETE FROM Tarefas WHERE Id = @id";
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        }
}
