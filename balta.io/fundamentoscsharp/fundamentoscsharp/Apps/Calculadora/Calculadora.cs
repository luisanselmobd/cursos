using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentoscsharp.Programas.Calculadora
{
    class Calculadora
    {
        int resultado;
        void RealizarOperacao(int a, int b, Operacoes operacao)
        {
            switch (operacao)
            {
                case Operacoes.Somar:
                    resultado = Somar(a, b);
                    break;
                case Operacoes.Subtrair:
                    resultado = Subtrair(a, b);
                    break;
                case Operacoes.Dividir:
                    resultado = Dividir(a, b);
                    break;
                case Operacoes.Multiplicar:
                    resultado = Multiplicar(a, b);
                    break;
            }
            Console.WriteLine($"\nRESULTADO: {resultado}");
        }
        int Somar(int a, int b) { return a + b; }
        int Subtrair(int a, int b) { return a - b; }
        int Dividir(int a, int b) { return a / b; }
        int Multiplicar(int a, int b) { return a * b; }
        string ConstruirMenuOpcoes()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("Escolha qual operação você deseja realizar:");

            var lista = Enum.GetValues(typeof(Operacoes));
            foreach (var item in lista)
            {
                menu.AppendLine($"{(int)item + 1} - {item}");
            }
            menu.Append("0 - Sair");
            return menu.ToString();
        }
        int ImprimirMenuOperacoes()
        {
            Console.WriteLine(ConstruirMenuOpcoes());

            int operacaoEscolhida;
            bool operacaoValida;

            do
            {
                ConsoleKeyInfo escolha = Console.ReadKey();

                if (!int.TryParse(Char.ToString(escolha.KeyChar), out operacaoEscolhida))
                {
                    Console.WriteLine("Valor inválido! Digite novamente!");
                    continue;
                }

                if (operacaoEscolhida == 0)
                    return -1;

                if (!Enum.IsDefined(typeof(Operacoes), operacaoEscolhida - 1))
                {
                    Console.WriteLine("Valor inválido! Digite novamente!");
                    continue;
                }

                return operacaoEscolhida - 1;

            } while (true);

        }
        int ImprimirMenuNumeros(int numero, Operacoes operacao)
        {
            
            Console.Write($"\nDigite o {numero}º número inteiro para {operacao.ToString().ToLower()} e confirme com 'Enter':");
            do
            {
                string escolhaUsuario = Console.ReadLine();
                int numeroEscolhido;

                if (!int.TryParse(escolhaUsuario, out numeroEscolhido))
                {
                    Console.Write("Valor inválido! Digite novamente e confirme com 'Enter'!");
                    continue;
                }

                return numeroEscolhido;

            } while (true);

        }
        public void Executar()
        {        
            int operacao;
            string sair;

            do
            {
                Console.Clear();
                operacao = ImprimirMenuOperacoes();
                if (operacao == -1)
                    break;
                Console.Clear();
                int n1 = ImprimirMenuNumeros(1, (Operacoes)operacao);
                int n2 = ImprimirMenuNumeros(2, (Operacoes)operacao);
                RealizarOperacao(n1, n2, (Operacoes)operacao);
                Console.WriteLine("\nPara sair, digite ESC.\nPara fazer outra operação, digite qualquer outra tecla.");
                

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }

    enum Operacoes
    {
        Somar,
        Subtrair,
        Dividir,
        Multiplicar
    }

}
