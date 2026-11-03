using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

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

            int opcao = ConfirmacaoEntrada();

            return ConfirmarOpcaoMenu(opcao);
        }


        public static int ConfirmacaoEntrada()
        {
            Console.Write("\nEscolha uma opção: ");
            bool resultado = int.TryParse(Console.ReadLine(), out int opcao);
            while (!resultado)
            {
                Console.WriteLine("Por favor, insira um número válido.");
                resultado = int.TryParse(Console.ReadLine(), out opcao);
            }
            return opcao;
        }

        public static int ConfirmarOpcaoMenu(int opcao)
        {
            while (opcao < 1 || opcao > 5)
            {
                Console.WriteLine("Opção inválida. Escolha uma opção de 1 a 5.");
                opcao = ConfirmacaoEntrada();
            }

            return opcao;
        }

        
        public static Tarefa ObterDadosTarefa()
        {
            Console.WriteLine("\nDigite o título da tarefa: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("\nDigite a descrição da tarefa: ");
            string descricao = Console.ReadLine();
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
            string concluidaInput = Console.ReadLine();


            while(concluidaInput.ToLower() != "s" && concluidaInput.ToLower() != "n")
            {
                Console.WriteLine("\nEntrada inválida. Por favor, digite 's' para sim ou 'n' para não.");
                concluidaInput = Console.ReadLine();
            }

            bool concluida = concluidaInput.ToLower() == "s";

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
            Console.WriteLine("\nDigite o ID da tarefa: ");
            bool resultado = int.TryParse(Console.ReadLine(), out int id);
            while (!resultado || id <= 0)
            {
                Console.WriteLine("Por favor, insira um número válido.");
                resultado = int.TryParse(Console.ReadLine(), out id);
            }
            return id;
        }

















    }
}
