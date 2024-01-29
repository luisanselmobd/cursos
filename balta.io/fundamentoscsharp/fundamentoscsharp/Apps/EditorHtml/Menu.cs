using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace fundamentoscsharp.Programas.EditorHtml
{
    internal class Menu
    {
        public string ConstruirColunas(int tamanho, char caracteresLaterais, char caracterePrincipal)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(caracteresLaterais);
            for (int i = 0; i < tamanho; i++)
            {
                sb.Append(caracterePrincipal);
            }
            sb.Append(caracteresLaterais);
            return sb.ToString();
        }

        public string ConstruirLinhas(int tamanhoLinha, int tamanhoColuna)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tamanhoLinha; i++)
            {
                sb.Append(ConstruirColunas(tamanhoColuna, '|', ' '));
                if (i != tamanhoLinha - 1)
                    sb.Append(Environment.NewLine);

            }


            return sb.ToString();
        }

        public string ConstruirMoldula(int tamanhoColunas, int tamanhoLinhas)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ConstruirColunas(tamanhoColunas, '+', '-'));
            sb.AppendLine(ConstruirLinhas(tamanhoLinhas, tamanhoColunas));
            sb.Append(ConstruirColunas(tamanhoColunas, '+', '-'));
            return sb.ToString();
        }

        void ImprimirLinha(string texto, int linha)
        {
            Console.SetCursorPosition(3, linha);
            Console.WriteLine(texto);
        }

        public int ImprimirMenu()
        {
            string opcaoEscolhida;
            bool repetir = true;
            int linhaConsole = 1;
            int nroLinhas = 10;
            int nroColunas = 50;

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ConstruirMoldula(nroColunas, nroLinhas));


            ImprimirLinha("O que você deseja fazer?", linhaConsole++);
            ImprimirLinha("1 - Criar arquivo", linhaConsole++);
            ImprimirLinha("2 - Abrir arquivo", linhaConsole++);
            ImprimirLinha("3 - Sair", linhaConsole++);
            Console.SetCursorPosition(3, linhaConsole++);

            do
            {
                opcaoEscolhida = char.ConvertFromUtf32(Console.ReadKey().KeyChar);
                switch (opcaoEscolhida)
                {
                    case "1":
                    case "2":
                    case "3":
                        repetir = false;
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    default:
                        ImprimirLinha("Valor inválido. Digite um caractere válido!", linhaConsole++);
                        Console.SetCursorPosition(3, linhaConsole++);                        
                        break;
                }
            } while (linhaConsole != nroLinhas && repetir);
            if (repetir)
                return 4;
            return Convert.ToInt32(opcaoEscolhida);
        }

    }
}
