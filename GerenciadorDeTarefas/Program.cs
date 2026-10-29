using GerenciadorDeTarefas;
using MySql.Data.MySqlClient;




int opcao = 0;
TarefaRepository tarefaRepository = new TarefaRepository();


while (opcao != 5)
{
    InterfaceUsuario.Cabecalho();

    opcao = InterfaceUsuario.ObterOpcaoMenu();

    switch (opcao)
    {
        case 1:
            Tarefa tarefa = InterfaceUsuario.ObterDadosTarefa();
            tarefaRepository.AdicionarTarefa(tarefa);
            break;
        case 2:
            List<Tarefa> tarefas = tarefaRepository.ListarTarefas();
            InterfaceUsuario.ExibirTarefas(tarefas);
            break;
        case 3:
            // Atualizar tarefa
            break;

        case 4:
            // Excluir tarefa
            break;

        case 5:
            Console.WriteLine("Encerrando o programa...");
            break;
    }
}




