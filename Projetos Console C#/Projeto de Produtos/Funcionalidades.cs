using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_de_Produtos
{
    public class Funcionalidades
    {
        public static void Mensagem(string mensagem, ConsoleColor color = ConsoleColor.Red) {
            Console.ForegroundColor = color;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.WriteLine($"Aperte ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Titulo(string mensagem, ConsoleColor color = ConsoleColor.DarkMagenta) {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
    }
}