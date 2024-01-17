using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentoscsharp
{
    class Calculadora
    {
        private int resultado;

        public void RealizarOperacao(int a, int b, Operacoes operacao)
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
            Console.WriteLine($"RESULTADO: {resultado}"); 
        }

        int Somar(int a, int b) { return a + b; }
        int Subtrair(int a, int b) { return a - b; }
        int Dividir(int a, int b) { return a / b;}
        int Multiplicar(int a, int b) { return a * b; }


        public string ConstruirMenuOpcoes()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("Escolha qual operação você deseja realizar:");

            var lista = Enum.GetValues(typeof(Operacoes));
            foreach (var item in lista)
            {
                menu.AppendLine($"{(int)item + 1} - {item}");
            }
            menu.AppendLine("0 - Sair");
            return menu.ToString();
        }
        public int ImprimirMenuOperacoes()
        {
            Console.WriteLine(ConstruirMenuOpcoes());

            int operacaoEscolhida;
            bool operacaoValida;

            do
            {
                string escolhaUsuario = Console.ReadLine();

                if (!int.TryParse(escolhaUsuario, out operacaoEscolhida))
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

        public int ImprimirMenuNumeros(int numero)
        {
            Console.WriteLine($"Digite o {numero}º número inteiro:");
            do
            {
                string escolhaUsuario = Console.ReadLine();
                int numeroEscolhido;

                if (!int.TryParse(escolhaUsuario, out numeroEscolhido))
                {
                    Console.WriteLine("Valor inválido! Digite novamente!");
                    continue;
                }

                return numeroEscolhido;

            } while (true);

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
