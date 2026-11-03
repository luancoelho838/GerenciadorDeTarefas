using GerenciadorDeTarefas;



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
            bool cadastrado = tarefaRepository.AdicionarTarefa(tarefa);
            InterfaceUsuario.ExibirResultadoCadastro(cadastrado);
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
            InterfaceUsuario.ExibirResultadoAtualizacao(atualizado);
            break;

        case 4:
            int idExcluir = InterfaceUsuario.ObterIdTarefa();
            bool excluido = tarefaRepository.ExcluirTarefa(idExcluir);
            InterfaceUsuario.ExibirResultadoExclusao(excluido);
            break;

        case 5:
            Console.WriteLine("Encerrando o programa...");
            break;
    }
}




