using GerenciadorDeTarefas;
using MySql.Data.MySqlClient;


Tarefa tarefa = new Tarefa
{
    Titulo = "Estudar C#",
    Descricao = "Estudar os conceitos de C# e .NET",
    DataVencimento = DateTime.Now.AddDays(7),
    Concluida = false
};

TarefaRepository tarefaRepository = new TarefaRepository();
tarefaRepository.AdicionarTarefa(tarefa);