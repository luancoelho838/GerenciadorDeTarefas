using System;
using System.Collections.Generic;
using System.Globalization;

namespace GerenciadorDeTarefas
{
    internal class InterfaceUsuario
    {



        public static void Cabecalho()
        {
            DateTime agora = DateTime.Now;
            string cabecalho = agora.ToString("dddd, dd 'de' MMMM 'de' yyyy - HH:mm", new CultureInfo("pt-BR"));

            cabecalho = char.ToUpper(cabecalho[0]) + cabecalho.Substring(1);

            Console.WriteLine(cabecalho);
        }


        public static void ExibirMenu()
        {
            Console.WriteLine("\n\t\t===== GERENCIADOR DE TAREFAS =====\n");
            Console.WriteLine("Selecione uma opção:\n");

            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Atualizar Tarefa");
            Console.WriteLine("4. Excluir Tarefa");
            Console.WriteLine("5. Sair");
        }


        public static int ObterOpcaoMenu()
        {
            ExibirMenu();

            int opcao = ObterNumeroInteiro(1, "\nEscolha uma opção de 1 a 5: ");

            return ValidarOpcaoMenu(opcao);
        }


        public static int ObterNumeroInteiro(int minimo, string mensagem)
        {
            Console.Write(mensagem);
            bool resultado = int.TryParse(Console.ReadLine(), out int opcao);
            while (!resultado || opcao < minimo)
            {
                Console.WriteLine("Por favor, insira um número válido.");
                Console.WriteLine(mensagem);
                resultado = int.TryParse(Console.ReadLine(), out opcao);
            }
            return opcao;
        }

        public static int ValidarOpcaoMenu(int opcao)
        {
            while (opcao < 1 || opcao > 5)
            {
                Console.WriteLine("Opção inválida. Escolha uma opção de 1 a 5.");
                opcao = ObterNumeroInteiro(1, "\nEscolha uma opção de 1 a 5: ");
            }

            return opcao;
        }

        
        public static Tarefa ObterDadosTarefa()
        {
            string titulo = ObterTitulo();
            string descricao = ObterDescricao();

            DateTime dataVencimento;
            while (true)
            {
                Console.WriteLine("\nDigite a data de vencimento (dd/MM/yyyy): ");
                string dataVencimentoInput = Console.ReadLine();
                if (DateTime.TryParseExact(dataVencimentoInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataVencimento))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nData inválida. Por favor, insira uma data no formato dd/MM/yyyy.");
                }
            }

            Console.WriteLine("\nA tarefa está concluída? (s/n): ");
            string concluidaInput = Console.ReadLine()?.Trim();

            while (!string.Equals(concluidaInput, "s", StringComparison.OrdinalIgnoreCase) &&
                   !string.Equals(concluidaInput, "n", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nEntrada inválida. Digite 's' ou 'n'.");
                concluidaInput = Console.ReadLine()?.Trim();
            }

            bool concluida = string.Equals(concluidaInput, "s", StringComparison.OrdinalIgnoreCase);

            return new Tarefa
            {
                Titulo = titulo,
                Descricao = descricao,
                DataVencimento = dataVencimento,
                Concluida = concluida
            };  
        }



        public static void ExibirTarefas(List<Tarefa> tarefas)
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }
            Console.WriteLine("\nLista de Tarefas:\n");
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"ID: {tarefa.Id}");
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao ?? "Nenhuma descrição fornecida"}");
                Console.WriteLine($"Data de Vencimento: {tarefa.DataVencimento.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Concluída: {(tarefa.Concluida ? "Sim" : "Não")}");
                Console.WriteLine(new string('-', 30));
            }
        }




        public static int ObterIdTarefa()
        {
            return ObterNumeroInteiro(1, "\nDigite o ID da tarefa: ");
        }


        public static void ExibirResultadoAtualizacao(bool atualizado)
        {
            if (atualizado)
            {
                Console.WriteLine("Tarefa atualizada com sucesso.");
            }
            else
            {
                Console.WriteLine("Nenhuma tarefa foi atualizada. Verifique o ID informado.\n");
            }
        }



        public static void ExibirResultadoExclusao(bool excluido)
        {
            if (excluido)
            {
                Console.WriteLine("Tarefa excluída com sucesso.");
            }
            else
            {
                Console.WriteLine("Nenhuma tarefa foi excluída. Verifique o ID informado.\n");
            }
        }



        public static void ExibirResultadoCadastro(bool cadastrado)
        {
            if (cadastrado)
            {
                Console.WriteLine("Tarefa cadastrada com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar a tarefa. Tente novamente.\n");
            }
        }



        public static string ObterTitulo()
        {
            Console.WriteLine("\nDigite o título da tarefa: ");
            string titulo = Console.ReadLine();
            while(string.IsNullOrEmpty(titulo) || titulo.Length > 80)
            {
                Console.WriteLine("\nO título deve ter entre 1 e 80 caracteres. Digite novamente: ");
                titulo = Console.ReadLine();
            }

            return titulo;
        }



        public static string ObterDescricao()
        {
            Console.WriteLine("\nDigite a descrição da tarefa: ");
            string descricao = Console.ReadLine() ?? string.Empty;
            while (descricao.Length > 200)
            {
                Console.WriteLine("\nA descrição deve ter menos de 200 caracteres. Digite novamente: ");
                descricao = Console.ReadLine();
            }

            return descricao;
        }









    }
}
