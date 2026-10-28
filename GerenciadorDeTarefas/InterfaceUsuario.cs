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











        











    }
}
