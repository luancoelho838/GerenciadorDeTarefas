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
            try
            {
                Tarefa tarefa = InterfaceUsuario.ObterDadosTarefa();
                bool cadastrado = tarefaRepository.AdicionarTarefa(tarefa);
                InterfaceUsuario.ExibirResultadoCadastro(cadastrado);
            }
            catch (MySqlException ex)
            {
                InterfaceUsuario.ExibirErroBD("Ocorreu um erro durante a operação no banco de dados", ex);
            }
            catch (Exception ex)
            {
                InterfaceUsuario.ExibirErro("Erro ao cadastrar a tarefa", ex);
            }
            break;

        case 2:
            try
            {
                List<Tarefa> tarefas = tarefaRepository.ListarTarefas();
                InterfaceUsuario.ExibirTarefas(tarefas);
            }
            catch (MySqlException ex)
            {
                InterfaceUsuario.ExibirErroBD("Ocorreu um erro durante a operação no banco de dados", ex);
            }
            catch (Exception ex)
            {
                InterfaceUsuario.ExibirErro("Erro ao listar as tarefas", ex);
            }
            break;

        case 3:
            try
            {
                int id = InterfaceUsuario.ObterIdTarefa();

                if (!tarefaRepository.ExisteTarefa(id))
                {
                    Console.WriteLine($"Tarefa com ID {id} não encontrada.");
                    break;
                }
                    Tarefa atualizarTarefa = InterfaceUsuario.ObterDadosTarefa();
                    atualizarTarefa.Id = id;
                    bool atualizado = tarefaRepository.AtualizarTarefa(atualizarTarefa);
                    InterfaceUsuario.ExibirResultadoAtualizacao(atualizado);
                }
            catch (MySqlException ex)
            {
                InterfaceUsuario.ExibirErroBD("Ocorreu um erro durante a operação no banco de dados", ex);
            }
            catch (Exception ex)
            {
                InterfaceUsuario.ExibirErro("Erro ao atualizar a tarefa", ex);
            }
            break;

        case 4:
            try
            {
                int idExcluir = InterfaceUsuario.ObterIdTarefa();

                if (!tarefaRepository.ExisteTarefa(idExcluir)){
                    Console.WriteLine($"Tarefa com ID {idExcluir} não encontrada.");
                    break;
                }

                bool excluido = tarefaRepository.ExcluirTarefa(idExcluir);
                InterfaceUsuario.ExibirResultadoExclusao(excluido);
            }
            catch (MySqlException ex)
            {
                InterfaceUsuario.ExibirErroBD("Ocorreu um erro durante a operação no banco de dados", ex);
            }
            catch (Exception ex)
            {
                InterfaceUsuario.ExibirErro("Erro ao excluir a tarefa", ex);
            }
            break;

        case 5:
            Console.WriteLine("Encerrando o programa...");
            break;
    }
}




