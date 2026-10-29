using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GerenciadorDeTarefas
{
    internal class InterfaceUsuario
    {



        public static void BoasVindas()
        {
            DateTime agora = DateTime.Now;
            string cabecalho = agora.ToString("dddd, dd 'de' MMMM 'de' yyyy - HH:mm", new CultureInfo("pt-BR"));

            cabecalho = char.ToUpper(cabecalho[0]) + cabecalho.Substring(1);

            Console.WriteLine(cabecalho);
        }


        public static void ExibirMenu()
        {
            Console.WriteLine("\t\t\t===== GERENCIADOR DE TAREFAS =====\n");
            Console.WriteLine("Selecione uma opção:\n");

            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Atualizar Tarefa");
            Console.WriteLine("4. Excluir Tarefa");
            Console.WriteLine("5. Sair");
        }


        public static int ConfirmacaoEntrada()
        {
            Console.Write("Escolha uma opção: ");
            bool resultado = int.TryParse(Console.ReadLine(), out int opcao);
            while (!resultado)
            {
                Console.WriteLine("Por favor, insira um número válido.");
                resultado = int.TryParse(Console.ReadLine(), out opcao);
            }
            return opcao;
        }
























    }
}
