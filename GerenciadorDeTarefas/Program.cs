using GerenciadorDeTarefas;
using MySql.Data.MySqlClient;


//Tarefa novaTarefa = new Tarefa
//{
//    Titulo = "Estudar C#",
//    Descricao = "Estudar os conceitos de C# e .NET",
//    DataVencimento = DateTime.Now.AddDays(7),
//    Concluida = false
//};

TarefaRepository tarefaRepository = new TarefaRepository();
//tarefaRepository.AdicionarTarefa(novaTarefa);

List<Tarefa> tarefas = tarefaRepository.ListarTarefas();

foreach (Tarefa tarefa in tarefas)
{
    Console.WriteLine(
        $"Id: {tarefa.Id}, Título: {tarefa.Titulo}, " +
        $"Descrição: {tarefa.Descricao}, " +
        $"Vencimento: {tarefa.DataVencimento:dd/MM/yyyy}, " +
        $"Concluída: {tarefa.Concluida}"
    );
}


tarefaRepository.AtualizarTarefa(new Tarefa
{
    Id = 1, 
    Titulo = "Estudar Python",
    Descricao = "Estudar os conceitos de Python",
    DataVencimento = DateTime.Now.AddDays(10),
    Concluida = true
});


tarefaRepository.ExcluirTarefa(1);