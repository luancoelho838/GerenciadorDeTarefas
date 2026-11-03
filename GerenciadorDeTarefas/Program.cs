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
            int id = InterfaceUsuario.ObterIdTarefa();
            Tarefa atualizarTarefa = InterfaceUsuario.ObterDadosTarefa();
            atualizarTarefa.Id = id;
            bool atualizado = tarefaRepository.AtualizarTarefa(atualizarTarefa);

            if (atualizado)
            {
                Console.WriteLine("Tarefa atualizada com sucesso.");
            }
            else
            {
                Console.WriteLine("Nenhuma tarefa foi atualizada. Verifique o ID informado.\n");
            }
            break;
        case 4:
            int idExcluir = InterfaceUsuario.ObterIdTarefa();
            bool excluido = tarefaRepository.ExcluirTarefa(idExcluir);

            if (excluido)
            {
                Console.WriteLine("Tarefa excluída com sucesso.");
            }
            else
            {
                Console.WriteLine("Nenhuma tarefa foi excluída. Verifique o ID informado.\n");
            }
            break;
        case 5:
            Console.WriteLine("Encerrando o programa...");
            break;
    }
}




